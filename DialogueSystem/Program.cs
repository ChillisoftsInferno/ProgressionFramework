namespace DialogueSystem;

public static class Program
{
    public static void Main(string[] args)
    {
        JsonParser jsonParser = new JsonParser();
        jsonParser.LoadJson();
        DialogueMenu dialogueMenu = new DialogueMenu(jsonParser.CharacterDialogues);
        PlayerController playerController = new PlayerController();
        "Select a save by entering a number. Enter 0 for a new save.".NextLine().WriteOverTime();
        var saveNum = "";
        while (string.IsNullOrEmpty(saveNum))
        {
            saveNum = Console.ReadLine();
        }

        var savedNum = int.Parse(saveNum) - 1;
        if (savedNum >= jsonParser.LoadAllPlayerSaves()!.Count)
            throw new ArgumentOutOfRangeException(nameof(saveNum));
        if (savedNum < 0) savedNum = jsonParser.LoadAllPlayerSaves()!.Count - 1;
        
        playerController.CurrentSave = jsonParser.LoadPlayerSaveById(savedNum) ?? throw new ArgumentNullException(nameof(playerController.CurrentSave));
        CharacterDialogueHelper.SetPlayerRelationships(playerController.CurrentSave.SavedData.First().Relationships);

        "Enter a character name to talk to them.".NextLine().WriteOverTime();
        "Available characters:".NextLine().WriteOverTime(secondsToWaitForNext:0.25);

        var characters = dialogueMenu.GetCharacters();
        foreach (var character in characters)
        {
            character.CharacterName.WriteOverTime(0.25,0.25);
        }
        Console.WriteLine();
        var characterName = "";
        while (string.IsNullOrEmpty(characterName))
        {
            characterName = Console.ReadLine();
        }
        dialogueMenu.RunCharacterDialogue(characterName);

        var responseNum = "";
        while (string.IsNullOrEmpty(responseNum))
        {
            responseNum = Console.ReadLine();
        }
        CharacterDialogueHelper.CheckForValidPlayerResponse(int.Parse(responseNum));
        playerController.CurrentSave.SavedData.First().Relationships = CharacterDialogueHelper.GetPlayerRelationships();
        
        jsonParser.SavePlayerData(playerController.CurrentSave);
    }
}