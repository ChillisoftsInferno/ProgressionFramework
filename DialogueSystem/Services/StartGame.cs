using System.Globalization;
using DialogueSystem.Helpers;
using DialogueSystem.Interfaces;
using DialogueSystem.Providers;
using DialogueSystem.UI.Components;
using NLog;

namespace DialogueSystem.Services;

public class StartGame : IStartGame
{
    private readonly IJsonParser _jsonParser;
    private readonly IPlayerController _playerController;
    private readonly IDialogueManager _dialogueManager;
    private readonly IDialogueMenu _dialogueMenu;
    private readonly MyLogger logger = MyLogger.GetInstance();

    public StartGame
    (
        IJsonParser jsonParser,
        IPlayerController playerController,
        IDialogueManager dialogueManager,
        IDialogueMenu dialogueMenu
    )
    {
        _jsonParser = jsonParser ?? throw new ArgumentNullException(nameof(jsonParser));
        _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
        _dialogueManager = dialogueManager ?? throw new ArgumentNullException(nameof(dialogueManager));
        _dialogueMenu = dialogueMenu ?? throw new ArgumentNullException(nameof(dialogueMenu));
    }

    public void Launch()
    {
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
        logger.Info("Viewing Select View");
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
                Launch();
                break;
        }
    }
}
