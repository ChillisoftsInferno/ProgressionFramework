namespace DialogueSystem;

public static class Program
{
    public static void Main(string[] args)
    {
        JsonParser jsonParser = new JsonParser();
        jsonParser.LoadJson();
        DialogueManager dialogueManager = new DialogueManager(jsonParser.CharacterDialogues);
        PlayerController playerController = new PlayerController();
        playerController.CurrentSave = jsonParser.LoadSavedPlayerData(1) ?? throw new ArgumentNullException(nameof(playerController.CurrentSave));
        CharacterDialogueHelper.SetPlayerRelationships(playerController.CurrentSave.SavedData.First().Relationships);


        Console.WriteLine("Enter a character name to talk to them.".NextLine());
        Console.WriteLine("Available characters:".NextLine());

        var characters = dialogueManager.GetCharacters();
        foreach (var character in characters)
        {
            Console.WriteLine(character.CharacterName);
        }
        Console.WriteLine();
        var characterName = "";
        while (string.IsNullOrEmpty(characterName))
        {
            characterName = Console.ReadLine();
        }
        dialogueManager.RunCharacterDialogue(characterName);
    }
}