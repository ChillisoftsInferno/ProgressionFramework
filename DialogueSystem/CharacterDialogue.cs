namespace DialogueSystem;

public class CharacterDialogue
{
    public string DialogueId { get; set; }
    public string ConversationHistory { get; set; }
    public List<TextSet> TextSets { get; set; }
}
