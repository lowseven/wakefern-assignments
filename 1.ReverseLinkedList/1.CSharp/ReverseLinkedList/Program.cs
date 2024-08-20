
using ReverseLinkedList;

var ll = new SinglyLinkedList<int>
{//this will call the SinglyLinkedList.Add(..) method internally
    1,
    2,
    3,
    4,
    5
};

//printout the SinglyLinkedList values in console
foreach (int i in ll)
    Console.WriteLine(i);

