// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DialogueSystem.Helpers;
using DialogueSystem.Interfaces;
using Microsoft.Extensions.Logging;

namespace DialogueSystem.Services;

public class StartGame
(
    IJsonParser jsonParser,
    IPlayerController playerController,
    IDialogueManager dialogueManager,
    IDialogueMenu dialogueMenu,
    ILogger<StartGame> logger
)
    : IStartGame
{
    private readonly IJsonParser _jsonParser = jsonParser ?? throw new ArgumentNullException(nameof(jsonParser));
    private readonly IPlayerController _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
    private readonly IDialogueManager _dialogueManager = dialogueManager ?? throw new ArgumentNullException(nameof(dialogueManager));
    private readonly IDialogueMenu _dialogueMenu = dialogueMenu ?? throw new ArgumentNullException(nameof(dialogueMenu));
    private readonly ILogger<StartGame> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public void Launch()
    {
        _logger.Log(LogLevel.Information, "StartGame Initialized");
        RunGame();
    }

    private void RunGame()
    {
        while (true)
        {
            LoadContent();
            PlayGame();
            SaveGame();
            if (!Restart()) break;
        }
    }

    private void SelectMenu_View()
    {
        
    }

    private void Relationships_View()
    {
        
    }

    private void LoadContent()
    {
        _jsonParser.LoadJson();
        _dialogueManager.RunLoadSaveSequence();
    }

    private void PlayGame()
    {
        _dialogueMenu.RunCharacterDialogue();
        CharacterDialogueHelper.CheckForValidPlayerResponse();
    }

    private void SaveGame()
    {
        _playerController.GetCurrentSave().SavedData.First().Relationships = CharacterDialogueHelper.GetPlayerRelationships();
        "Would you like to overwrite the current save? [Y/N]".NextLine().WriteOverTime();
        bool nextSave = InputHelper.GetYesNoOutput();
        _jsonParser.SavePlayerData(_playerController.GetCurrentSave(), nextSave);
    }

    private bool Restart()
    {
        "Would you like to play again? [Y/N]".NextLine().WriteOverTime();
        return InputHelper.GetYesNoOutput();
    }
}
