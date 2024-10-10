// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using System.Globalization;

namespace DialogueSystem;

public class DialogueMenu(List<Character> characters) : IDialogueMenu
{
    private readonly List<Character> _characterDialogues = characters;

    public void RunCharacterDialogue(string characterName)
    {
        var selectedCharacter = characters.FirstOrDefault(c => c.CharacterName == characterName);
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

    public List<Character> GetCharacters() => characters;
}
