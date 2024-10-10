// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DialogueSystem.Interfaces;

namespace DialogueSystem;

public class DialogueManager : IDialogueManager
{
    private readonly JsonParser _jsonParser;
    private readonly DialogueMenu _dialogueMenu;
    private readonly PlayerController _playerController;
    
    public DialogueManager(JsonParser jsonParser, DialogueMenu dialogueMenu, PlayerController playerController)
    {
        _jsonParser = jsonParser ?? throw new ArgumentNullException(nameof(jsonParser));
        _dialogueMenu = dialogueMenu ?? throw new ArgumentNullException(nameof(dialogueMenu));
        _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
    }

    public void RunDialogueSequence()
    {
        LoadSaveMenu();
        ExecuteSaveMenu();
    }
    
    private void LoadSaveMenu()
    {
        "Select a save by entering a number. Enter 0 for a new save.".NextLine().WriteOverTime();
        Console.WriteLine("Load Save:");
        foreach (var save in _jsonParser.LoadAllPlayerSaves()!)
        {
            Console.WriteLine(save.SaveId);
        }

        CharacterDialogueHelper.RunLoadingIndicator(2);
    }

    private void ExecuteSaveMenu()
    {
        var savedNum = InputHelper.GetNumericOutput();
        
        if (savedNum > _jsonParser.LoadAllPlayerSaves()!.Count)
            throw new ArgumentOutOfRangeException(nameof(savedNum));
        
        if (savedNum == 0) savedNum = _jsonParser.LoadAllPlayerSaves()!.Count;
        
        _playerController.CurrentSave = _jsonParser.LoadPlayerSaveById(savedNum) ?? throw new ArgumentNullException(nameof(_playerController.CurrentSave));
        CharacterDialogueHelper.SetPlayerRelationships(_playerController.CurrentSave.SavedData.First().Relationships);
    }

    private void LoadCharacterDialogueInteractionMenu()
    {
        "Enter a character name to talk to them.".NextLine().WriteOverTime();
        "Available characters:".NextLine().WriteOverTime(secondsToWaitForNext:0.25);

        var characters = _dialogueMenu.GetCharacters();
        foreach (var character in characters)
        {
            character.CharacterName.WriteOverTime(0.25,0.25);
        }
    }
}
