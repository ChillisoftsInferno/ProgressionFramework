using GlobalHelpers;

namespace DialogueSystem;

public static class CharacterDialogueHelper
{
    private static List<Relationship>? s_playerRelationships;

    public static void SetPlayerRelationships(List<Relationship> playerRelationships)
    {
        s_playerRelationships = playerRelationships ?? throw new ArgumentNullException(nameof(playerRelationships));
    }

    
    
    private static string NextLine(this string text)
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

    public static void ExecuteDialogueSet(this DialogueSet dialogueSet)
    {
        Console.WriteLine($"Dialogue Set Id: {dialogueSet.DialogueSetId}".NextLine());
        Console.WriteLine($"");
    }
}
