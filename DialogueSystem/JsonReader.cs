using GlobalHelpers;
using Newtonsoft.Json;

namespace DialogueSystem;

public class JsonReader
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
    
    private void SetCharacterList(List<Character> set)
    {
        CharacterDialogues = set;
    }
}
