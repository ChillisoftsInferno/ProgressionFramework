namespace GenericDataStructures.Helpers;

internal class Node<T>
{
    public int Id { get; set; }
    public T? Data { get; set; }
    public Node<T>? Parent { get; set; }
    public List<Node<T>>? Children { get; set; }
    
    public Node(int id, T? data, Node<T>? parent = null, List<Node<T>>? children = null)
    {
        Id = id;
        Data = data;
        Parent = parent;
        Children = children;
    }
}
