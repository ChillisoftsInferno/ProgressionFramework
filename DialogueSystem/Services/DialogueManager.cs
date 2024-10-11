// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DialogueSystem.Helpers;
using DialogueSystem.Interfaces;

namespace DialogueSystem.Services;

public class DialogueManager : IDialogueManager
{
    private readonly IJsonParser _jsonParser;
    private readonly IDialogueMenu _dialogueMenu;
    private readonly IPlayerController _playerController;
    
    public DialogueManager(IJsonParser jsonParser, IDialogueMenu dialogueMenu, IPlayerController playerController)
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
        CharacterDialogueHelper.RunLoadingIndicator(2);

        "Select a save by entering a number. Enter 0 for a new save.".NextLine().WriteOverTime();
        Console.WriteLine("Load Save:");
        foreach (var save in _jsonParser.LoadAllPlayerSaves()!)
        {
            Console.WriteLine(save.SaveId);
        }
        Console.Write("Save to load: ");
    }

    private void ExecuteSaveMenu()
    {
        var savedNum = InputHelper.GetNumericOutput();
        
        if (savedNum > _jsonParser.LoadAllPlayerSaves()!.Count)
            throw new ArgumentOutOfRangeException(nameof(savedNum));
        
        if (savedNum == 0) savedNum = _jsonParser.LoadAllPlayerSaves()!.Count;

        _playerController.SetCurrentSave(_jsonParser.LoadPlayerSaveById(savedNum) ?? throw new ArgumentNullException(nameof(savedNum)));
        CharacterDialogueHelper.SetPlayerRelationships(_playerController.GetCurrentSave().SavedData.First().Relationships);
    }

    private void LoadCharacterDialogueInteractionMenu()
    {
        "Enter a character name to talk to them.".NextLine().WriteOverTime();
        "Available characters:".NextLine().WriteOverTime(secondsToWaitForNext:0.25);

        var characters = _dialogueMenu.GetCharacterDialogues();
        foreach (var character in characters)
        {
            character.CharacterName.WriteOverTime(0.25,0.25);
        }
    }
}
