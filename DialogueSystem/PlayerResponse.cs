namespace DialogueSystem;

public class PlayerResponse
{
    public int ResponseId { get; set; }
    public string Text { get; set; }
    public int RelationshipInfluence { get; set; }
    public int CharacterKarmaInfluence { get; set; }
    public NextDialogue NextDialogue { get; set; }
}
