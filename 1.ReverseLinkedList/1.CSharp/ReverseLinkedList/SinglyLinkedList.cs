using System.Collections;

namespace ReverseLinkedList;

public sealed class Node<TT>(TT? data, Node<TT>? next)
{
    public readonly TT? _value = data;
    public Node<TT>? next = next;
}

public sealed class SinglyLinkedList<T> : IEnumerable<T>
{
    public int Count => _size;

    private Node<T>? _head;
    private Node<T>? _tail;
    private int _size;

    public bool IsEmpty => _tail is null && _head is null;

    public T? this[int index] => ItemAt(index);

    public SinglyLinkedList()
    {
        this._size = 0;
        this._tail = this._head = null;
    }

    public SinglyLinkedList(IEnumerable<T> items) : base()
    {
        if (items is not null)
        {
            foreach (var item in items)
                this.Add(item);
        }
    }

    public T? ItemAt(int index)
    {
        if (IsEmpty
            || index > this._size)
            throw new ArgumentOutOfRangeException($"Invalid value {index}");

        var elementIdx = 0;
        var locatedNode = this._head;
        while (index != elementIdx
            && locatedNode is not null)
        {
            locatedNode = locatedNode.next;
            elementIdx++;
        }

        return locatedNode is null
            ? default : locatedNode!._value;
    }

    public void AddAt(T value, int index)
    {
        if (IsEmpty || index == 0)
            this.AddFirst(value);
        else if (index > this.Count)
            throw new ArgumentOutOfRangeException($"Invalid value {index}");
        else
        {
            var elementIdx = 0;
            var locatedNode = this._head;
            while (elementIdx < index - 1
                && locatedNode!.next is not null)
            {
                locatedNode = locatedNode.next;
                elementIdx++;
            }

            var newNode = new Node<T>(value, null);
            newNode.next = locatedNode!.next!.next;
            locatedNode.next = newNode;
        }
    }

    public int Add(T? item)
    {
        if (IsEmpty)
        {
            this._head = this._tail = new Node<T>(item, null);
        }
        else
        {
            var newNode = new Node<T>(item, null);
            this._tail!.next = newNode;
            this._tail = newNode;
        }

        this._size++;

        return this.Count;
    }

    public void AddFirst(T? item)
    {
        var node = new Node<T>(item, _head);
        this._head = node;

        if (IsEmpty)
            _tail = _head;

        this._size++;
    }

    public T? Remove(T item)
    {
        var prevNode = _head;

        T? res = default;

        if (_head is null)
            return res;

        Node<T>? node;
        if (this._head._value?.Equals(item) is true)
        {
            this._head = this._head.next;
        }
        else
        {
            node = this._head.next;
            while (node is not null && (node._value?.Equals(item) is false))
            {
                prevNode = node;
                node = node!.next;
            }

            if (node is null)
                throw new InvalidOperationException($"Cannot find item {item}");

            prevNode!.next = node.next;
            res = node._value;
        }

        this._size--;
        return res;
    }

    public void ReverseList()
    {
        if (IsEmpty)
            return;

        Node<T> curr = this._head;
        Node<T>? prev = null;

        while (curr != null)
        {
            var tempNode = curr.next;
            curr.next = prev;

            prev = curr;
            curr = tempNode;
        }

        this._head = prev;
    }

    public T? FindItem(T item)
    {
        if (IsEmpty
            || item is null)
            return default;

        var locatedNode = this._head;
        while (locatedNode is not null)
        {
            if (locatedNode._value?.Equals(item) ?? false)
                return locatedNode._value;
            locatedNode = locatedNode.next;
        }

        return locatedNode is null
            ? default : locatedNode!._value;
    }


    public IEnumerator<T> GetEnumerator()
    {
        var node = this._head;
        while (node is not null)
        {
            var avalue = node._value;
            node = node.next;
            yield return avalue!;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}