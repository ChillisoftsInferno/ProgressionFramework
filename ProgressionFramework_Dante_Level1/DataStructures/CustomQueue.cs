using System.Collections;

namespace ProgressionFramework_Dante_Level1.DataStructures;

public class CustomQueue<T> : IEnumerable<T>
{
    private T[] _items;
    private int _head;
    private int _tail;
    private int _count;
    private const int DefaultCapacity = 4;

    public CustomQueue()
    {
        _items = new T[DefaultCapacity];
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    public int Count => _count;
    public bool IsEmpty => _count == 0;

    public void Enqueue(T item)
    {
        if (_count == _items.Length)
        {
            T[] newArray = new T[_items.Length * 2];
            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _items[(_head + i) % _items.Length];
            }
            _items = newArray;
            _head = 0;
            _tail = _count;
        }

        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
        T item = _items[_head];
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        _count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
        return _items[_head];
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _items[(_head + i) % _items.Length];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}