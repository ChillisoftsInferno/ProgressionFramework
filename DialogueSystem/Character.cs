namespace DialogueSystem;

public class Character
{
    public string CharacterName { get; set; }
    public int RelationshipToPlayer { get; set; }
    public List<DialogueSet> DialogueSets { get; set; }
}
