using ProgressionFramework_Dante_Level0.FunSiteActivities.JSON;

namespace Program;

public static class Program
{
    public static void Main(string[] args)
    {
        JsonReader jsonReader = new JsonReader();
        jsonReader.LoadJson();
        RunDialogue(jsonReader);
        RunTreeDataStructure(jsonReader);
    }

    private static void RunDialogue(JsonReader jsonReader)
    {
        
        var dialogueSets = jsonReader.GetDialogueSets();
        Console.Clear();
        foreach(var set in dialogueSets)
        {
            Console.WriteLine($"Dialogue Set Id: {set.DialogueSetId}\n");
            Console.WriteLine("Characters:");
            foreach (var character in set.Characters)
            {
                Console.WriteLine($"Name: {character.Name}");
            }
            Console.WriteLine();

            foreach (var dialogue in set.Dialogues)
            {
                string? characterName = set.Characters
                    .Where(character => character.CharacterId == dialogue.CharacterId)
                    .Select(character => character.Name)
                    .FirstOrDefault();
                string action = dialogue.Text.Substring(0, dialogue.Text.LastIndexOf(']') + 1);
                string characterDialogue = dialogue.Text.Remove(0, dialogue.Text.LastIndexOf(']') + 1);
                if (!string.IsNullOrEmpty(characterName))
                {
                    dialogue.Text = dialogue.Text.Insert(dialogue.Text.LastOrDefault(']') + 2, characterName);
                    Console.WriteLine
                    (
                        $"{action}\n" +
                        $"{characterName}:{characterDialogue}"
                    );
                }
                else
                {
                    Console.WriteLine
                    (
                        $"{action}\n" +
                        $"{characterDialogue}"
                    );
                }
            }
        }
        Console.ReadLine();
    }

    private static void RunTreeDataStructure(JsonReader jsonReader)
    {
        var tree = jsonReader.GetTreeDataStructure();
        Console.Clear();
        Console.WriteLine("Normal Traversal ->");
        tree.Traverse(tree.Root, value => 
            Console.WriteLine
            (
                $"ID: {value.NodeId}\n" + 
                $"1st Value: {value.FirstValue}\n" +
                $"2nd Value: {value.FirstValue}"));
        Console.WriteLine("DFS Traversal ->");
        Console.ReadLine();
    }

    // private static List<NodeValues>? GetChildren(Tree<NodeValues> tree, int depth)
    // {
    //     var children = new List<NodeValues>();
    //     var node = tree.Root.Value.FindById(tree.Root, depth);
    //     if (node != null)
    //     {
    //         if(node.Left != null) children.Add(node.Left.Value);
    //         if(node.Right != null) children.Add(node.Right.Value);
    //     }
    //
    //     return children;
    // }
}