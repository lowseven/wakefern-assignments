
public class Main {

	public static void main(String[] args) {
		SinglyLinkedList<Integer> ll = new SinglyLinkedList<>();
		
		//1.Insert at the end
		ll.add(1);
		ll.add(2);
		ll.add(3);
		ll.add(4);
		ll.add(5);
		
		for(int value : ll) {
			System.out.println("LinkedList.Add: " + value);
		}
		
		//2.Insert at the beginning
		System.out.println("===========");
		ll = new SinglyLinkedList<>();
		ll.addFirst(1);
		ll.addFirst(2);
		ll.addFirst(3);
		ll.addFirst(4);
		ll.addFirst(5);
		
		for(int value : ll) {
			System.out.println("LinkedList.addAtBeginning: " + value);
		}
		
		//2.Insert at the middle
		System.out.println("===========");
		ll = new SinglyLinkedList<>();
		ll.add(1);
		ll.add(2);
		ll.add(3);
		ll.add(4);
		ll.add(5);
		ll.AddAt(999, 3);
		
		for(int value : ll) {
			System.out.println("LinkedList.AddAtMiddle: " + value);
		}
		
		//3.Insert at the end
		System.out.println("===========");
		ll = new SinglyLinkedList<>();
		ll.add(1);
		ll.add(2);
		ll.add(3);
		ll.add(4);
		ll.add(5);
		ll.AddAt(999, 4);
		
		for(int value : ll) {
			System.out.println("LinkedList.AddAtEnd: " + value);
		}
		
		//4.delete at the start
		System.out.println("===========");
		ll = new SinglyLinkedList<>();
		ll.add(1);
		ll.add(2);
		ll.add(3);
		ll.add(4);
		ll.add(5);
		ll.remove(1);
		
		for(int value : ll) {
			System.out.println("LinkedList.removeAtStart: " + value);
		}
		
		//5.delete at the middle
		System.out.println("===========");
		ll = new SinglyLinkedList<>();
		ll.add(1);
		ll.add(2);
		ll.add(3);
		ll.add(4);
		ll.add(5);
		ll.remove(4);
		
		for(int value : ll) {
			System.out.println("LinkedList.removeAtMiddle: " + value);
		}
		
		//6.delete at the end
		System.out.println("===========");
		ll = new SinglyLinkedList<>();
		ll.add(1);
		ll.add(2);
		ll.add(3);
		ll.add(4);
		ll.add(5);
		ll.remove(5);
		
		for(int value : ll) {
			System.out.println("LinkedList.removeAtEnd: " + value);
		}
		
		//7.Search an element
		System.out.println("===========");
		ll = new SinglyLinkedList<>();
		ll.add(1);
		ll.add(2);
		ll.add(3);
		ll.add(4);
		ll.add(5);
		System.out.println("LinkedList.findItem: " + ll.findItem(2));

		
		//8.reverse the linked list
		System.out.println("===========");
		ll = new SinglyLinkedList<>();
		ll.add(1);
		ll.add(2);
		ll.add(3);
		ll.add(4);
		ll.add(5);
		ll.reverseList();
		
		for(int value : ll) {
			System.out.println("LinkedList.ReverseList: " + value);
		}
	}

}


