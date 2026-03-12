namespace ProgressionFramework_Dante_Level1.DataStructures;

public static class DataStructureConverter
{
    public static CustomQueue<T> ToQueue<T>(IEnumerable<T> source)
    {
        var queue = new CustomQueue<T>();
        foreach (var item in source)
        {
            queue.Enqueue(item);
        }
        return queue;
    }

    public static CustomStack<T> ToStack<T>(IEnumerable<T> source)
    {
        var stack = new CustomStack<T>();
        foreach (var item in source)
        {
            stack.Push(item);
        }
        return stack;
    }

    public static CustomLinkedList<T> ToLinkedList<T>(IEnumerable<T> source)
    {
        var list = new CustomLinkedList<T>();
        foreach (var item in source)
        {
            list.AddLast(item);
        }
        return list;
    }

    public static CustomStack<T> ConvertToStack<T>(CustomQueue<T> queue) => ToStack(queue);
    public static CustomStack<T> ConvertToStack<T>(CustomLinkedList<T> list) => ToStack(list);

    public static CustomQueue<T> ConvertToQueue<T>(CustomStack<T> stack) => ToQueue(stack);
    public static CustomQueue<T> ConvertToQueue<T>(CustomLinkedList<T> list) => ToQueue(list);

    public static CustomLinkedList<T> ConvertToLinkedList<T>(CustomStack<T> stack) => ToLinkedList(stack);
    public static CustomLinkedList<T> ConvertToLinkedList<T>(CustomQueue<T> queue) => ToLinkedList(queue);
}