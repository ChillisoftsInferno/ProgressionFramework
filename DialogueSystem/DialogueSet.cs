namespace DialogueSystem;

public class DialogueSet
{
    public int DialogueSetId { get; set; }
    public int RelationshipLevel { get; set; }
    public int KarmaLevel { get; set; }
    public List<CharacterDialogue> CharacterDialogues { get; set; }
}
