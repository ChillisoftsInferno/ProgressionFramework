// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DialogueSystem.Domain;
using DialogueSystem.Helpers;
using DialogueSystem.Interfaces;
using GlobalHelpers.Helpers;

namespace DialogueSystem.Services;

public class DialogueMenu : IDialogueMenu
{
    private List<Character> _characterDialogues;

    public void SetCharacterDialogues(List<Character> characterDialogues) => _characterDialogues = characterDialogues;

    public void RunCharacterDialogue()
    {
        Console.Write("\nCharacter Name: ");
        string characterName = InputHelper.GetTextOutput();
        var selectedCharacter = _characterDialogues.FirstOrDefault(c => c.CharacterName == characterName);
        if (selectedCharacter == null) return;
        
        selectedCharacter.ExecuteCharacterDialogue();        
    }

    public void RunPlayerResponse()
    {
        var playerResponses = CharacterDialogueHelper.GetValidPlayerResponses();
        var chosenResponse = Console.ReadLine();
        int chosenNum = 0;
        while (string.IsNullOrEmpty(chosenResponse))
        {
            chosenResponse = Console.ReadLine();
            if(string.IsNullOrEmpty(chosenResponse)) continue;
            try
            {
                var responseNum = int.Parse(chosenResponse);
                if (responseNum.GetType() != typeof(int))
                {
                    continue;
                }

                if (responseNum > playerResponses?.Count)
                {
                    continue;
                }

                chosenNum = responseNum;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public List<Character> GetCharacterDialogues() => _characterDialogues;
}
