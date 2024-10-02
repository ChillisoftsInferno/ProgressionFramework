namespace DialogueSystem;

public class TextSet
{
    public int TextId { get; set; }
    public string Text { get; set; }
    public List<PlayerResponse> PlayerResponses { get; set; }
}
