using System.Text.Json;
using DialogueSystem.Domain;
using DialogueSystem.Helpers;
using DialogueSystem.Interfaces;
using GlobalHelpers;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DialogueSystem.Services;

public class JsonParser : IJsonParser
{
    private readonly IDialogueMenu _dialogueMenu;

    private string _playerSaveFilePath = "../../../../GlobalHelpers/Resources/JSON/PlayerSaveData.json";
    private string _dialogueTreeFilePath = "../../../../GlobalHelpers/Resources/JSON/RPGDialogueTree.json";
    
    private PlayerSave _currentSave;

    public JsonParser(IDialogueMenu dialogueMenu)
    {
        _dialogueMenu = dialogueMenu ?? throw new ArgumentNullException(nameof(dialogueMenu));
    }

    public void LoadJson()
    {
        using (StreamReader r = new StreamReader(_dialogueTreeFilePath))
        {
            string json = r.ReadToEnd();
            
            List<Character>? charactersList = JsonConvert.DeserializeObject<List<Character>>(json);
            if (charactersList != null)
            {
                SetCharacterList(charactersList);
            }
        }
    }
    
    public List<PlayerSave> LoadAllPlayerSaves()
    {
        using (StreamReader r = new StreamReader(_playerSaveFilePath))
        {
            string json = r.ReadToEnd();

            List<PlayerSave>? playerSaves = JsonConvert.DeserializeObject<List<PlayerSave>>(json);
            if (playerSaves.IsNull()) throw new ArgumentNullException(nameof(playerSaves));
            return playerSaves!;
        }
    }

    public PlayerSave LoadPlayerSaveById(int saveId)
    {
        using (StreamReader r = new StreamReader(_playerSaveFilePath))
        {
            string json = r.ReadToEnd();

            List<PlayerSave>? playerSaves = JsonConvert.DeserializeObject<List<PlayerSave>>(json);
            if (playerSaves.IsNull()) throw new ArgumentNullException(nameof(playerSaves));
            var playerSave = playerSaves!.FirstOrDefault(s => s.SaveId == saveId);
            if (playerSave.IsNull()) throw new ArgumentNullException(nameof(playerSave));
            _currentSave = playerSave!;
            return playerSave!;
        }
    }

    public PlayerSave GetLatestPlayerSave()
    {
        return LoadAllPlayerSaves().OrderByDescending(s => s.SaveId).First();
    }

    public void SavePlayerData(PlayerSave save, bool shouldOverwrite)
    {
        var allSaves = LoadAllPlayerSaves();

        if (!shouldOverwrite)
        {
            int saveCount = allSaves.FirstOrDefault()?.SaveId + 1 ?? 1;
            Console.WriteLine("Please enter a save name.");
            string saveName = InputHelper.GetTextOutput();
            var newSave = new PlayerSave
            {
                SaveId = saveCount,
                SaveName = saveName,
                SavedData = save.SavedData,
                Archived = false
            };
            _currentSave = newSave;
            allSaves.Add(newSave);
        }
        else
        {
            var currentSave = allSaves.FirstOrDefault(s => s.SaveId == save.SaveId) ??
                              throw new ArgumentNullException(nameof(save.SaveId));
            allSaves.Remove(currentSave);
            allSaves.Add(save);
            _currentSave = currentSave;
        }
        
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var orderedSaves = allSaves.OrderByDescending(s => s.SaveId);
        string jsonSave = JsonSerializer.Serialize(orderedSaves, options);
        File.WriteAllText(_playerSaveFilePath, jsonSave);
        
        Console.WriteLine($"Game Saved");
    }
    
    private void SetCharacterList(List<Character> set)
    {
        _dialogueMenu.SetCharacterDialogues(set);
    }

    public PlayerSave GetCurrentSave() => _currentSave;
}
