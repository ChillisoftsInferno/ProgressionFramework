// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DialogueSystem.Domain;
using DialogueSystem.Helpers;
using DialogueSystem.Interfaces;
using NLog;

namespace DialogueSystem.Services;

public class DialogueManager : IDialogueManager
{
    private readonly IJsonParser _jsonParser;
    private readonly IDialogueMenu _dialogueMenu;
    private readonly IPlayerController _playerController;
    private readonly MyLogger logger = MyLogger.GetInstance();
    
    public DialogueManager(IJsonParser jsonParser, IDialogueMenu dialogueMenu, IPlayerController playerController)
    {
        _jsonParser = jsonParser ?? throw new ArgumentNullException(nameof(jsonParser));
        _dialogueMenu = dialogueMenu ?? throw new ArgumentNullException(nameof(dialogueMenu));
        _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
    }

    public void RunLoadSaveSequence()
    {
        if (HasForExistingSaves())
        {
            LoadSaveMenu();
            ExecuteSaveMenu();
        }
        else
        {
            ExecuteNewGame();
        }
        Console.Clear();
    }

    private bool HasForExistingSaves()
    {
        return _jsonParser.LoadAllPlayerSaves().Count > 1;
    }
    
    private void LoadSaveMenu()
    {
        OutputHelper.RunLoadingIndicator();

        "Select a save by entering a number. Enter 0 for a new save.".NextLine().WriteOverTime();
        Console.WriteLine("Saved Games:");
        foreach (var save in _jsonParser.LoadAllPlayerSaves()!.Where(s => s.SaveId > 0))
        {
            Console.WriteLine($"{save.SaveId}: {save.SaveName}");
        }
        Console.Write("Load save number: ");
    }

    private void ExecuteNewGame()
    {
        Console.WriteLine("Starting New Game...");
        int savedNum = 0;
        var defaultSave = _jsonParser.LoadPlayerSaveById(savedNum) ?? throw new ArgumentNullException(nameof(savedNum),"Default save not found!");
        var newSave = defaultSave.Clone();
        _jsonParser.SavePlayerData(newSave, false);
        var latestSave = _jsonParser.GetLatestPlayerSave();
        _playerController.SetCurrentSave(latestSave);
        CharacterDialogueHelper.SetPlayerRelationships(latestSave.SavedData.First().Relationships);
    }

    private void ExecuteSaveMenu()
    {
        int savedNum = InputHelper.GetNumericOutput();
        int amountOfSaves = _jsonParser.LoadAllPlayerSaves()?.Count ?? throw new ArgumentOutOfRangeException(nameof(amountOfSaves));
         
        if (savedNum > amountOfSaves)
            throw new ArgumentOutOfRangeException(nameof(savedNum));

        if (savedNum == 0)
        {
            logger.Info($"No save files found, creating a new save file.");
            ExecuteNewGame();
        }
        else
        {
            _playerController.SetCurrentSave(_jsonParser.LoadPlayerSaveById(savedNum) ?? throw new ArgumentNullException(nameof(savedNum)));
            var save = _playerController.GetCurrentSave();
            logger.Info($"Attempting to load save: <Save>Name>{save.SaveName}<Name/><Id> {save.SaveId}</Id></Save>");
        }

        CharacterDialogueHelper.SetPlayerRelationships(_playerController.GetCurrentSave().SavedData.First().Relationships);
    }

    public void LoadCharacterDialogueInteractionMenu()
    {
        OutputHelper.RunLoadingIndicator();
        "Enter a character name to talk to them.".NextLine().WriteOverTime();
        "\nAvailable characters:".NextLine().WriteOverTime(secondsToWaitForNext:0.25);

        var characters = _dialogueMenu.GetCharacterDialogues();
        foreach (var character in characters)
        {
            character.CharacterName.NextLine().WriteOverTime(0.25,0.25);
        }
    }
}
