using GlobalHelpers;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DialogueSystem;

public class JsonParser
{
    public List<Character> CharacterDialogues = new List<Character>();

    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("../../../../GlobalHelpers/Resources/JSON/RPGDialogueTree.json"))
        {
            string json = r.ReadToEnd();
            
            List<Character>? charactersList = JsonConvert.DeserializeObject<List<Character>>(json);
            if (charactersList != null)
            {
                SetCharacterList(charactersList);
            }
        }
    }
    
    public List<PlayerSave>? LoadPlayerSaves()
    {
        using (StreamReader r = new StreamReader("../../../../GlobalHelpers/Resources/JSON/PlayerSaves.json"))
        {
            string json = r.ReadToEnd();

            List<PlayerSave>? playerSaves = JsonConvert.DeserializeObject<List<PlayerSave>>(json);
            if (playerSaves.IsNull()) return null;
            return playerSaves;
        }
    }

    public PlayerSave? LoadSavedPlayerData(int saveId)
    {
        using (StreamReader r = new StreamReader("../../../../GlobalHelpers/Resources/JSON/PlayerSaveData.json"))
        {
            string json = r.ReadToEnd();

            List<PlayerSave>? playerSaves = JsonConvert.DeserializeObject<List<PlayerSave>>(json);
            if (playerSaves.IsNull()) return null;
            var playerSave = playerSaves!.FirstOrDefault(s => s.SaveId == saveId);
            if (playerSave.IsNull()) return null;
            return playerSave;
        }
    }

    public void SavePlayerData(PlayerSave save)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string jsonSave = JsonSerializer.Serialize(save, options);
        string filePath = "person.json";
        File.WriteAllText(filePath, jsonSave);

        Console.WriteLine($"JSON data saved to {filePath}");
    }
    
    private void SetCharacterList(List<Character> set)
    {
        CharacterDialogues = set;
    }
}
