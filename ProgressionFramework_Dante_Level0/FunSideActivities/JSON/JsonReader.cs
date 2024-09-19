using GlobalHelpers;
using Newtonsoft.Json;

namespace ProgressionFramework_Dante_Level0.FunSideActivities.JSON;

public class JsonReader
{
    private List<DialogueSet> _dialogueSets = new();
    private Tree<NodeValues> _treeDataStructure = null!;

    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("../../../../GlobalHelpers/Resources/JSON/Dialogue.json"))
        {
            string json = r.ReadToEnd();
            List<DialogueSet>? dialogueSets = JsonConvert.DeserializeObject<List<DialogueSet>>(json);
            
            if (dialogueSets != null)
            {
                SetDialogueSet(dialogueSets);
            }
        }

        using (StreamReader r = new StreamReader("../../../../GlobalHelpers/Resources/JSON/TreeNodeValues.json"))
        {
            string json = r.ReadToEnd();
            List<NodeValues>? nodeValuesList = JsonConvert.DeserializeObject<List<NodeValues>>(json);
            if (nodeValuesList != null)
            {
                AssignTreeDataStructureValues(nodeValuesList);
            }
        }
    }

    private void SetDialogueSet(List<DialogueSet> set)
    {
        _dialogueSets = set;
    }

    private void AssignTreeDataStructureValues(List<NodeValues> data)
    {
        _treeDataStructure = new Tree<NodeValues>(data[0]);

        for (int i = 1; i < 12; i++)
        {
            _treeDataStructure.Add(data[i]);
        }
    }

    public List<DialogueSet> GetDialogueSets() => _dialogueSets;

    public Tree<NodeValues> GetTreeDataStructure() => _treeDataStructure ?? throw new ArgumentNullException("", "Tree data structure was null.");
}
    
public class DialogueSet
{
    public int DialogueSetId { get; set; }
    public Character[] Characters { get; set; }
    public Dialogue[] Dialogues { get; set; }
    public Context Context { get; set; }
}

public class Character
{
    public int CharacterId { get; set; }
    public string Name { get; set; }
}

public class Dialogue
{
    public int DialogueId { get; set; }
    public int CharacterId { get; set; }
    public string Text { get; set; }
}

public class Context
{
    public int ContextId { get; set; }
    public string Setting { get; set; }
    public string Backstory { get; set; }
    public string Development { get; set; }
    public string Extra { get; set; }
}

public class NodeValues
{
    public int NodeId { get; set; }
    public int FirstValue { get; set; }
    public int SecondValue { get; set; }

    public Node<NodeValues>? FindById(Node<NodeValues>? node, int id)
    {
        if (node == null) return null;
        if (node.Value.NodeId == id) return node;
        
        Node<NodeValues>? result = null;
        while (result == null && node is { Left: not null, Right: not null })
        {
            result = FindById(node.Left, id);
            if (result != null) break;
            result = FindById(node.Right, id);
            if (result != null) break;
        }
        return result;
    }
}