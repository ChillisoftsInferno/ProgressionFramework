using System.Globalization;
using DialogueSystem.Helpers;
using DialogueSystem.Interfaces;
using DialogueSystem.Providers;
using DialogueSystem.UI.Components;
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
        LoadContent();
        SelectMenu_View();
    }

    private void RunGame()
    {
        while (true)
        {
            PlayGame();
            SaveGame();
            if (!Restart()) break;
        }
        SelectMenu_View();
    }

    private void SelectMenu_View()
    {
        Console.Clear();
        $"Current Save: {_jsonParser.GetCurrentSave().SaveName}".TwoLines().WriteQuick();
        "Select a menu by entering one of the assigned symbols.".NextLine().WriteQuick();
        "[D]ialogue".NextLine().WriteQuick();
        "[R]elationships".NextLine().WriteQuick();
        "[Q]uit".NextLine().WriteQuick();

        string input = InputHelper.GetConsoleKeyOutput();
        SelectMenu(input);
    }

    private void Relationships_View()
    {
        Console.Clear();
        var relationships = CharacterDialogueHelper.GetPlayerRelationships();
        "Relationships".NextLine().WriteQuick();
        foreach (var relationship in relationships)
        {
            string characterName = $"{relationship.CharacterName}: ";
            string progressBar = $"{new ProgressBar(relationship.RelationshipLevel, 100).Build()}";
            string outPut = string.Format(new CultureInfo("en-US"), "{0,-15} {1, -30}", characterName, progressBar);
            $"{outPut}".NextLine().WriteQuick();;
        }
        "\nPress [Enter] to continue".NextLine().WriteQuick();
        InputHelper.WaitForEnterKey();
        SelectMenu_View();
    }

    private void LoadContent()
    {
        _jsonParser.LoadJson();
        _dialogueManager.RunLoadSaveSequence();
    }

    private void PlayGame()
    {
        _dialogueManager.LoadCharacterDialogueInteractionMenu();
        _dialogueMenu.RunCharacterDialogue();
        CharacterDialogueHelper.CheckForValidPlayerResponse();
    }

    private void SaveGame()
    {
        _playerController.GetCurrentSave().SavedData.First().Relationships = CharacterDialogueHelper.GetPlayerRelationships();
        "Would you like to overwrite the current save? [Y/N]".NextLine().WriteOverTime();
        bool shouldOverwrite = InputHelper.GetYesNoOutput();
        _jsonParser.SavePlayerData(_playerController.GetCurrentSave(), shouldOverwrite);
    }

    private bool Restart()
    {
        "Would you like to play again? [Y/N]".NextLine().WriteOverTime();
        return InputHelper.GetYesNoOutput();
    }

    private void SelectMenu(string key)
    {
        switch (key)
        {
            case MenuOptionProvider.RelationshipMenuOption:
                Relationships_View();
                break;
            case MenuOptionProvider.DialogueMenuOption:
                RunGame();
                break;
            case MenuOptionProvider.QuitMenuOption:
                break;
        }
    }
}
