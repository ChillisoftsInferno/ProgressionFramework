namespace DialogueSystem;

public static class Program
{
    public static void Main(string[] args)
    {
        JsonReader jsonReader = new JsonReader();
        jsonReader.LoadJson();
        DialogueManager dialogueManager = new DialogueManager(jsonReader.CharacterDialogues);
        PlayerController playerController = new PlayerController();
        playerController.CurrentSave = jsonReader.LoadSavedPlayerData(1) ?? throw new ArgumentNullException(nameof(playerController.CurrentSave));
        CharacterDialogueHelper.SetPlayerRelationships(playerController.CurrentSave.SavedData.First().Relationships);


        var characterName = "";
        while (string.IsNullOrEmpty(characterName))
        {
            characterName = Console.ReadLine();
        }
        dialogueManager.RunCharacterDialogue(characterName);
    }
}