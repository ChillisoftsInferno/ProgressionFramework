// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DialogueSystem.Interfaces;

namespace DialogueSystem;

public class StartGame
(
    JsonParser jsonParser,
    PlayerController playerController,
    DialogueManager dialogueManager,
    DialogueMenu dialogueMenu
)
    : IStartGame
{
    private readonly JsonParser _jsonParser = jsonParser ?? throw new ArgumentNullException(nameof(jsonParser));
    private readonly PlayerController _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
    private readonly DialogueManager _dialogueManager = dialogueManager ?? throw new ArgumentNullException(nameof(dialogueManager));
    private readonly DialogueMenu _dialogueMenu = dialogueMenu ?? throw new ArgumentNullException(nameof(dialogueMenu));

    public void Launch()
    {
        LoadContent();
        _dialogueManager.RunDialogueSequence();
        _dialogueMenu.RunCharacterDialogue(InputHelper.GetTextOutput());
        CharacterDialogueHelper.CheckForValidPlayerResponse(InputHelper.GetNumericOutput());
        _playerController.CurrentSave.SavedData.First().Relationships = CharacterDialogueHelper.GetPlayerRelationships();
        
        "Would you like to overwrite the current save? [Y/N]".NextLine().WriteOverTime();
        var saveAnswer = Console.ReadKey(true).Key;

        bool nextSave = false;
        while (saveAnswer is not ConsoleKey.Y and ConsoleKey.N)
        {
            saveAnswer = Console.ReadKey(true).Key;
            nextSave = saveAnswer == ConsoleKey.Y;
        }
            
        _jsonParser.SavePlayerData(_playerController.CurrentSave, nextSave);
    }


    private void LoadContent()
    {
        _jsonParser.LoadJson();
    }
}
