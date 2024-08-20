public final class Node<T> {
    public final T value;
    public Node<T> next;

    public Node(T data, Node<T> next) {
        this.value = data;
        this.next = next;
    }
}