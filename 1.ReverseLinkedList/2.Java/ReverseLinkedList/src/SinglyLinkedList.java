import java.util.Iterator;

public final class SinglyLinkedList<T> implements Iterable<T> {
    private Node<T> head;
    private Node<T> tail;
    private int size;

    public int getCount() {
        return size;
    }

    public boolean isEmpty() {
        return tail == null && head == null;
    }

    public T get(int index) {
        return itemAt(index);
    }

    public SinglyLinkedList() {
        this.size = 0;
        this.tail = this.head = null;
    }

    public SinglyLinkedList(Iterable<T> items) {
        this();
        if (items != null) {
            for (T item : items) {
                this.add(item);
            }
        }
    }

    public T itemAt(int index) {
        if (isEmpty() || index >= this.size) {
            throw new IndexOutOfBoundsException("Invalid index: " + index);
        }

        int elementIdx = 0;
        Node<T> locatedNode = this.head;
        while (index != elementIdx && locatedNode != null) {
            locatedNode = locatedNode.next;
            elementIdx++;
        }

        return locatedNode == null ? null : locatedNode.value;
    }

    public int add(T item) {
        if (isEmpty()) {
            this.head = this.tail = new Node<>(item, null);
        } else {
            Node<T> newNode = new Node<>(item, null);
            this.tail.next = newNode;
            this.tail = newNode;
        }

        this.size++;

        return this.getCount();
    }

    public void addFirst(T item) {
        Node<T> node = new Node<>(item, head);
        this.head = node;

        if (isEmpty()) {
            tail = head;
        }

        this.size++;
    }

    public T remove(T item) {
        Node<T> prevNode = head;
        T result = null;

        if (head == null) {
            return result;
        }

        Node<T> node;
        if (head.value != null && head.value.equals(item)) {
            this.head = this.head.next;
        } else {
            node = this.head.next;
            while (node != null && (node.value == null || !node.value.equals(item))) {
                prevNode = node;
                node = node.next;
            }

            if (node == null) {
                throw new IllegalStateException("Cannot find item: " + item);
            }

            prevNode.next = node.next;
            result = node.value;
        }

        this.size--;
        return result;
    }

    public void reverseList() {
        if (isEmpty()) {
            return;
        }

        Node<T> curr = this.head;
        Node<T> prev = null;

        while (curr != null) {
            Node<T> tempNode = curr.next;
            curr.next = prev;

            prev = curr;
            curr = tempNode;
        }

        this.head = prev;
    }

    public T findItem(T item) {
        if (isEmpty() || item == null) {
            return null;
        }

        Node<T> locatedNode = this.head;
        while (locatedNode != null) {
            if (locatedNode.value != null && locatedNode.value.equals(item)) {
                return locatedNode.value;
            }
            locatedNode = locatedNode.next;
        }

        return locatedNode == null ? null : locatedNode.value;
    }
    
    public void AddAt(T value, int index)
    {
        if (isEmpty() || index == 0)
            this.addFirst(value);
        else if (index > this.getCount())
            throw new IndexOutOfBoundsException("Invalid value " + index);
        else
        {
            int elementIdx = 0;
            Node<T> locatedNode = this.head;
            while (elementIdx < index - 1
                && locatedNode.next != null)
            {
                locatedNode = locatedNode.next;
                elementIdx++;
            }

            var newNode = new Node<T>(value, null);
            newNode.next = locatedNode.next.next;
            locatedNode.next = newNode;
        }
    }

    @Override
    public Iterator<T> iterator() {
        return new Iterator<T>() {
            private Node<T> current = head;

            @Override
            public boolean hasNext() {
                return current != null;
            }

            @Override
            public T next() {
                T value = current.value;
                current = current.next;
                return value;
            }
        };
    }
}