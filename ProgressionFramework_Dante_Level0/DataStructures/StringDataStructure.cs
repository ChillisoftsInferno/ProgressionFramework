namespace ProgressionFramework_Dante_Level0.DataStructures;

public class StringDataStructure
{
    public void CreateTree()
    {
        var trie = new Tree();
        trie.Insert("apple");
        trie.Insert("app");
        trie.Insert("bat");

        Console.WriteLine(trie.Search("apple"));
        Console.WriteLine(trie.Search("app"));
        Console.WriteLine(trie.Search("appl"));
        Console.WriteLine(trie.StartsWith("ap"));
    }
}

public class TreeNode
{
    public Dictionary<char, TreeNode> Children { get; set; }
    public bool IsEndOfWord { get; set; }

    public TreeNode()
    {
        Children = new Dictionary<char, TreeNode>();
        IsEndOfWord = false;
    }
}

public class Tree
{
    private readonly TreeNode _root;

    public Tree()
    {
        _root = new TreeNode();
    }

    public void Insert(string word)
    {
        var current = _root;
        foreach (char c in word)
        {
            if (!current.Children.ContainsKey(c))
            {
                current.Children[c] = new TreeNode();
            }
            current = current.Children[c];
        }
        current.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        var current = _root;
        foreach (char c in word)
        {
            if (!current.Children.ContainsKey(c))
                return false;

            current = current.Children[c];
        }
        return current.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        var current = _root;
        foreach (char c in prefix)
        {
            if (!current.Children.ContainsKey(c))
                return false;

            current = current.Children[c];
        }
        return true;
    }
}
