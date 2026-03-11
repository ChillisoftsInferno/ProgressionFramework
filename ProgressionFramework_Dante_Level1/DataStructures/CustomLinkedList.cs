using System.Collections;

namespace ProgressionFramework_Dante_Level1.DataStructures;

public class CustomLinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    private Node? _head;
    private int _count;

    public int Count => _count;

    public void AddFirst(T value)
    {
        Node newNode = new Node(value)
        {
            Next = _head
        };
        _head = newNode;
        _count++;
    }

    public void AddLast(T value)
    {
        Node newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        _count++;
    }

    public bool Remove(T value)
    {
        if (_head == null) return false;

        if (EqualityComparer<T>.Default.Equals(_head.Value, value))
        {
            _head = _head.Next;
            _count--;
            return true;
        }

        Node current = _head;
        while (current.Next != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Next.Value, value))
            {
                current.Next = current.Next.Next;
                _count--;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public void Clear()
    {
        _head = null;
        _count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}