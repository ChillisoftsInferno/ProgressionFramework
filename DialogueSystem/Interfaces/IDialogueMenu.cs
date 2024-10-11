// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using DialogueSystem.Domain;

namespace DialogueSystem.Interfaces;

public interface IDialogueMenu
{
    public void SetCharacterDialogues(List<Character> characterDialogues);
    public void RunCharacterDialogue(string characterName);
    public void RunPlayerResponse();
    public List<Character> GetCharacterDialogues();
}
