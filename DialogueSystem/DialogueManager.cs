// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace DialogueSystem;

public class DialogueManager(List<Character> characters)
{
    private readonly List<Character> _characterDialogues = characters;

    public void RunCharacterDialogue(string characterName)
    {
        var selectedCharacter = characters.FirstOrDefault(c => c.CharacterName == characterName);
        if (selectedCharacter == null) return;
        
        selectedCharacter.ExecuteCharacterDialogue();        
    }
}
