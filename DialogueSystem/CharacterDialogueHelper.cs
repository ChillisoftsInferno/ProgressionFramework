using GlobalHelpers;

namespace DialogueSystem;

public static class CharacterDialogueHelper
{
    private static List<Relationship>? s_playerRelationships;

    public static void SetPlayerRelationships(List<Relationship> playerRelationships)
    {
        s_playerRelationships = playerRelationships ?? throw new ArgumentNullException(nameof(playerRelationships));
    }
    
    public static string NextLine(this string text)
    {
        text += "\n";
        return text;
    }
    
    public static void ExecuteCharacterDialogue(this Character character)
    {
        var characterRelationship = s_playerRelationships!.FirstOrDefault(r => r.CharacterName == character.CharacterName);
        if (characterRelationship.IsNull()) return;
        Console.WriteLine($"Character Name: {character.CharacterName}".NextLine());
        var availableSet = character.DialogueSets
            .FirstOrDefault(s => s.RelationshipLevel >= characterRelationship!.RelationshipLevel);
        if (availableSet.IsNull()) return;
        availableSet!.ExecuteDialogueSet();
    }

    private static void ExecuteDialogueSet(this DialogueSet dialogueSet)
    {
        Console.WriteLine($"Dialogue Set Id: {dialogueSet.DialogueSetId}".NextLine());
        Console.WriteLine($"Relationship Level: {dialogueSet.RelationshipLevel}".NextLine());
        Console.WriteLine($"Karma Level: {dialogueSet.KarmaLevel}".NextLine());
        var set = dialogueSet.CharacterDialogues.FirstOrDefault(cd => cd.ConversationHistory == "first_time");
        if (set.IsNull()) return;
        set!.ExecuteCharacterDialogue();
    }

    private static void ExecuteCharacterDialogue(this CharacterDialogue characterDialogue)
    {
        Console.WriteLine($"Character Dialogue Id: {characterDialogue.DialogueId}".NextLine());
        Console.WriteLine($"Conversation History: {characterDialogue.ConversationHistory}".NextLine());
    }
}
