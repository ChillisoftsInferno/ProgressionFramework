using DialogueSystem.Domain;
using GlobalHelpers;

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
    
    public static string NextLine(this string text)
    {
        text += "\n";
        return text;
    }
    
    public static void ExecuteCharacterDialogue(this Character character)
    {
        var characterRelationship = s_playerRelationships!.FirstOrDefault(r => r.CharacterName == character.CharacterName);
        if (characterRelationship.IsNull()) return;
        s_selectedCharacterName = character.CharacterName;
        Console.WriteLine($"Character Name: {character.CharacterName}".NextLine());
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
        
        $"\"{s_selectedTextSet.Text}\"".WriteOverTime(0.5,0.5);
        
        var responses = s_selectedTextSet.PlayerResponses 
                        ?? throw new ArgumentNullException(nameof(s_selectedTextSet.PlayerResponses));

        s_currentPlayerResponses = responses;

        foreach (var response in responses)
        {
            Console.WriteLine($"{responses.IndexOf(response) + 1}: {response.Text}");
        }
    }

    public static void CheckForValidPlayerResponse(int index)
    {
        if (index <= 0 || index > s_currentPlayerResponses.Count) throw new ArgumentOutOfRangeException(nameof(index));
        
        s_currentPlayerResponses[index - 1].ExecutePlayerResponse();
    }

    private static void ExecutePlayerResponse(this PlayerResponse response)
    {
        $"{response.Text}".WriteOverTime(0.5,0.5);
        
        var relationshipToAlter = s_playerRelationships?.FirstOrDefault(r => r.CharacterName == s_selectedCharacterName) 
                                  ?? throw new ArgumentNullException(nameof(s_selectedCharacterName));
        
        relationshipToAlter.RelationshipLevel += response.RelationshipInfluence;
    }
    
    public static void WriteOverTime(this string text, double secondsToGenerate = 1, double secondsToWaitForNext = 1)
    {
        int waitForNextTimer = Convert.ToInt32(secondsToWaitForNext * 1000) / 2;
        int timePerChar = Convert.ToInt32(secondsToGenerate * 1000 / text.Length);
        
        int counter = text.Length;
        int currentIndex = 0;
        while (currentIndex < counter)
        {
            Console.Write(text[currentIndex]);
            Thread.Sleep(timePerChar);
            currentIndex++;
        }
        Thread.Sleep(waitForNextTimer);
    }

    public static void RunLoadingIndicator(double secondsToWaitForNext)
    {
        int timesLoaded = 0;
        int waitForNextTimer = Convert.ToInt32(secondsToWaitForNext * 1000 / 3);
        while (timesLoaded < 3)
        {
            ClearCurrentConsoleLine();
            Console.Write("Loading");
            "...".WriteOverTime(1,0);
            timesLoaded++;
        }
        Console.Clear();
    }
    
    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, currentLineCursor);
        Console.Write(new string(' ', Console.WindowWidth));  // Overwrite the current line with spaces
        Console.SetCursorPosition(0, currentLineCursor);     // Move the cursor back to the start of the line
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
