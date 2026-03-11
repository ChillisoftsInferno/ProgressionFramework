using System.Collections;

namespace ProgressionFramework_Dante_Level1.DataStructures;

public class CustomStack<T> : IEnumerable<T>
{
    private T[] _items;
    private int _top;
    private const int DefaultCapacity = 4;

    public CustomStack()
    {
        _items = new T[DefaultCapacity];
        _top = -1;
    }

    public int Count => _top + 1;
    public bool IsEmpty => _top == -1;

    public void Push(T item)
    {
        if (_top == _items.Length - 1)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
        _items[++_top] = item;
    }

    public T Pop()
    {
        if (IsEmpty) throw new InvalidOperationException("Stack is empty.");
        T item = _items[_top];
        _items[_top--] = default!;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Stack is empty.");
        return _items[_top];
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = _top; i >= 0; i--)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}