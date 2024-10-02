using GlobalHelpers;
using ProgressionFramework_Dante_Level0.FunSideActivities.JSON;
using ProgressionFramework_Dante_Level0.FunSideActivities.Hashing;

namespace Program;

public static class Program
{
    public static void Main(string[] args)
    {
        //JSON and Tree Data Structure
        JsonReader jsonReader = new JsonReader();
        jsonReader.LoadJson();
        RunDialogue(jsonReader);
        //RunTreeDataStructure(jsonReader);
        
        //Creating Hash Codes
        //RunHashsetExample();
        
        //Using extension methods on enums
        // Console.WriteLine(EnumHelper.RandomizeStatus().Value());
        // Console.WriteLine(EnumHelper.RandomizeStatus().Value());
        // Console.WriteLine(EnumHelper.RandomizeStatus().Value());
        // Console.WriteLine(EnumHelper.RandomizeStatus().Value());
    }

    private static void RunDialogue(JsonReader jsonReader)
    {
        
        var dialogueSets = jsonReader.GetDialogueSets();
        Console.Clear();
        Console.ReadKey(true);
        Console.WriteLine($"Backstory: {dialogueSets[0].Context.Backstory}\n");
        foreach(var set in dialogueSets)
        {
            Console.WriteLine($"Dialogue Set Id: {set.DialogueSetId}\n");
            Console.WriteLine("Characters:");
            foreach (var character in set.Characters)
            {
                Console.WriteLine($"Name: {character.Name}");
            }
            Console.WriteLine();

            var context = new Context
            {
                ContextId = set.Context.ContextId,
                Setting = set.Context.Setting,
                Backstory = set.Context.Backstory,
                Development = set.Context.Development,
                Extra = set.Context.Extra
            };

            Console.WriteLine($"Setting: {context.Setting}\n");
            
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
            Console.WriteLine($"Development: {context.Development}\n");
            Console.WriteLine($"Extra: {context.Extra}\n");
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

    // TODO: Needs work
    // Not being used
    private static List<NodeValues>? GetChildren(Tree<NodeValues> tree, int depth)
    {
        var children = new List<NodeValues>();
        var node = tree.Root.Value.FindById(tree.Root, depth);
        if (node != null)
        {
            if(node.Left != null) children.Add(node.Left.Value);
            if(node.Right != null) children.Add(node.Right.Value);
        }
    
        return children;
    }

    private static void RunHashsetExample()
    {
        Console.WriteLine("Random generated hashed entries.");
        Hasher hasher = new Hasher(5,false,10, 8);
        hasher.SetIsGenerating(true);
        Console.WriteLine();
        
        Console.WriteLine("Generate your own hash codes with custom input data.");
        while (hasher.GetIsGenerating())
        {
            string result = CustomConsole.Ensure().ToUpper();
            hasher.ConvertToHashCode(result);    
        }
        Console.WriteLine();

        Console.WriteLine("Now retrieve the data by entering a hashed code.");
        while (true)
        {
            string convertedData = CustomConsole.Ensure();
            Console.WriteLine($"Data: {hasher.GetCodeByHash(convertedData)}");
            Console.WriteLine("Press 'Enter' to search for another value and 'Q' to quit.");
            if (Console.ReadKey(true).Key == ConsoleKey.Q) break;
        }
    }
}