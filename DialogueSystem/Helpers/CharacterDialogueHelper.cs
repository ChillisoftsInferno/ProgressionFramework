using DialogueSystem.Domain;
using GlobalHelpers;
using GlobalHelpers.Helpers;

namespace DialogueSystem.Helpers;

public static class CharacterDialogueHelper
{
    private static List<Relationship>? s_playerRelationships;
    private static TextSet? s_selectedTextSet;
    private static string s_selectedCharacterName;
    private static List<PlayerResponse> s_currentPlayerResponses;

    public static void SetPlayerRelationships(List<Relationship> playerRelationships)
    {
        s_playerRelationships = playerRelationships ?? throw new ArgumentNullException(nameof(playerRelationships));
    }

    public static List<Relationship> GetPlayerRelationships() => s_playerRelationships ?? throw new ArgumentNullException(nameof(s_playerRelationships));
    
    public static void ExecuteCharacterDialogue(this Character character)
    {
        var characterRelationship = s_playerRelationships!.FirstOrDefault(r => r.CharacterName == character.CharacterName);
        if (characterRelationship.IsNull()) throw new ArgumentNullException(nameof(characterRelationship));
        Console.Clear();
        Console.Write($"Character Name: {s_selectedCharacterName}");
        s_selectedCharacterName = character.CharacterName;
        var availableSet = character.DialogueSets.GetViableDialogueSet(characterRelationship!);
        if (availableSet.IsNull()) return;
        availableSet!.ExecuteDialogueSet();
    }

    private static void ExecuteDialogueSet(this DialogueSet dialogueSet)
    {
        Console.WriteLine($"Dialogue Set Id: {dialogueSet.DialogueSetId}");
        Console.WriteLine($"Relationship Level: {dialogueSet.RelationshipLevel}");
        Console.WriteLine($"Karma Level: {dialogueSet.KarmaLevel}".NextLine());
        var set = dialogueSet.CharacterDialogues.FirstOrDefault(cd => cd.ConversationHistory == "first_time");
        if (set.IsNull()) return;
        set!.ExecuteCharacterDialogue();
    }

    private static void ExecuteCharacterDialogue(this CharacterDialogue characterDialogue)
    {
        Console.WriteLine($"Character Dialogue Id: {characterDialogue.DialogueId}");
        Console.WriteLine($"Conversation History: {characterDialogue.ConversationHistory}".NextLine());
        
        s_selectedTextSet = characterDialogue.TextSet 
                            ?? throw new ArgumentNullException(nameof(characterDialogue.TextSet));
        
        $"\"{s_selectedTextSet.Text}\"".NextLine().WriteOverTime(0.5,0.5);
        
        var responses = s_selectedTextSet.PlayerResponses 
                        ?? throw new ArgumentNullException(nameof(s_selectedTextSet.PlayerResponses));

        s_currentPlayerResponses = responses;

        foreach (var response in responses)
        {
            Console.WriteLine($"{responses.IndexOf(response) + 1}: {response.Text}");
        }
    }

    public static void CheckForValidPlayerResponse()
    {
        int index = InputHelper.GetNumericOutput();
        if (index <= 0 || index > s_currentPlayerResponses.Count) throw new ArgumentOutOfRangeException(nameof(index));
        OutputHelper.ClearPreviousConsoleLine();
        
        s_currentPlayerResponses[index - 1].ExecutePlayerResponse();
    }

    private static void ExecutePlayerResponse(this PlayerResponse response)
    {
        $"Player: \"{response.Text}\"".NextLine().WriteOverTime(0.5,0.5);
        
        var relationshipToAlter = s_playerRelationships?.FirstOrDefault(r => r.CharacterName == s_selectedCharacterName) 
                                  ?? throw new ArgumentNullException(nameof(s_selectedCharacterName));
        
        $"Relationship: {response.RelationshipInfluence}".NextLine().WriteOverTime();
        relationshipToAlter.RelationshipLevel += response.RelationshipInfluence;
        if (relationshipToAlter.RelationshipLevel > 100) relationshipToAlter.RelationshipLevel = 100;
        ExecuteNextDialogue(response.NextDialogue);
    }

    private static void ExecuteNextDialogue(this NextDialogue nextDialogue)
    {
        $"{s_selectedCharacterName}: \"{nextDialogue.CharacterDialogue}\"".NextLine().WriteOverTime();
    }
    
    

    private static DialogueSet GetViableDialogueSet(this List<DialogueSet> sets, Relationship playerRelationship)
    {
        int viableValue = sets
            .Select(s => s.RelationshipLevel)
            .Where(s => s <= playerRelationship.RelationshipLevel)
            .Max();
        return sets
            .FirstOrDefault(s => s.RelationshipLevel == viableValue) 
               ?? throw new ArgumentNullException(nameof(viableValue));
    }

    public static List<PlayerResponse>? GetValidPlayerResponses() => s_selectedTextSet?.PlayerResponses;
}
