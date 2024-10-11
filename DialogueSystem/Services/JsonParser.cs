using System.Text.Json;
using DialogueSystem.Domain;
using DialogueSystem.Interfaces;
using GlobalHelpers;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DialogueSystem.Services;

public class JsonParser : IJsonParser
{
    public List<Character> CharacterDialogues = new List<Character>();

    private string _playerSaveFilePath = "../../../../GlobalHelpers/Resources/JSON/PlayerSaveData.json";
    private string _dialogueTreeFilePath = "../../../../GlobalHelpers/Resources/JSON/RPGDialogueTree.json";

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
    
    public List<PlayerSave>? LoadAllPlayerSaves()
    {
        using (StreamReader r = new StreamReader(_playerSaveFilePath))
        {
            string json = r.ReadToEnd();

            List<PlayerSave>? playerSaves = JsonConvert.DeserializeObject<List<PlayerSave>>(json);
            if (playerSaves.IsNull()) return null;
            return playerSaves;
        }
    }

    public PlayerSave? LoadPlayerSaveById(int saveId)
    {
        using (StreamReader r = new StreamReader(_playerSaveFilePath))
        {
            string json = r.ReadToEnd();

            List<PlayerSave>? playerSaves = JsonConvert.DeserializeObject<List<PlayerSave>>(json);
            if (playerSaves.IsNull()) return null;
            var playerSave = playerSaves!.FirstOrDefault(s => s.SaveId == saveId);
            if (playerSave.IsNull()) return null;
            return playerSave;
        }
    }

    public void SavePlayerData(PlayerSave save, bool nextSave)
    {
        var allSaves = LoadAllPlayerSaves() ?? null;
        if (allSaves == null) return;

        if (nextSave)
        {
            int saveCount = allSaves?.LastOrDefault()?.SaveId + 1 ?? 1;
            var newSave = new PlayerSave
            {
                SaveId = saveCount,
                SavedData = save.SavedData
            };
            allSaves?.Add(newSave);
        }
        
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        string jsonSave = JsonSerializer.Serialize(allSaves, options);
        File.WriteAllText(_playerSaveFilePath, jsonSave);
        
        Console.WriteLine($"Game Saved");
    }
    
    private void SetCharacterList(List<Character> set)
    {
        CharacterDialogues = set;
    }
}
