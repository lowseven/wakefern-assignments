using Bogus;
using FluentAssertions;
using ReverseLinkedList;

namespace ReverseLinkedListTests;

[TestClass]
public class ReverseLinkedListTest
{
    [TestMethod]
    public void SinglyLinkedList_CreateEmptyList()
    {
        //ARRANGE, ACT
        var ll = new SinglyLinkedList<int>();

        //ASSERT
        ll.Should().BeEmpty();
    }

    [TestMethod]
    public void SinglyLinkedList_AddItems()
    {
        //ARRANGE
        var randomNums = new Faker().Random;
        var expectedList = Enumerable.Range(10, 20).Select(i => randomNums.Int(1, 9999))
            .ToList();//to materialize the enumerable

        //ACT
        var ll = new SinglyLinkedList<int>(expectedList);

        //ASSERT
        ll.SequenceEqual(expectedList).Should().BeTrue();
    }

    [TestMethod]
    public void SinglyLinkedList_ShouldAddItem()
    {
        //ARRANGE
        var value = new Faker().Random.Int(1, 999);
        var ll = new SinglyLinkedList<int>();

        //ACT
        ll.Add(value);//add to the end

        //ASSERT
        ll[0].Should().Be(value);
    }

    [TestMethod]
    public void SinglyLinkedList_ShouldReturnItemInTheMiddle()
    {
        //ARRANGE
        var randomNums = new Faker().Random;
        var expectedList = Enumerable.Range(10, 20).Select(i => randomNums.Int(1, 9999))
            //!!.ToList() is important to materialize the Ienumerable collection !! ,
            //otherwhise the random generator will run
            //everytime returning different values everytime;
            .ToList();

        //ACT
        var ll = new SinglyLinkedList<int>(expectedList);

        //ASSERT
        ll[5].Should().Be(expectedList.ElementAt(5));//return an item from a given position
    }

    [TestMethod]
    public void SinglyLinkedList_WhenEmpty_ShouldThrowArgumentOutOfRangeException()
    {
        //ARRANGE
        var value = new Faker().Random.Int(1, 999);
        var ll = new SinglyLinkedList<int>();

        //ACT, ASSERT
        Func<int> action = () => ll[0];
        action.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }

    [TestMethod]
    public void SinglyLinkedList_ShouldAddAtTheBeginning()
    {
        //ARRANGE
        var randomNums = new Faker().Random;
        var expectedList = Enumerable.Range(10, 20).Select(i => randomNums.Int(1, 9999))
            //!!.ToList() is important to materialize the Ienumerable collection !! ,
            //otherwhise the random generator will run
            //everytime returning different values everytime;
            .ToList();
        var ll = new SinglyLinkedList<int>();

        //ACT
        expectedList.ForEach(item => ll.AddFirst(item));

        //ASSERT
        ll[0].Should().Be(expectedList.Last());
    }

    [TestMethod]
    public void SinglyLinkedList_ShouldRemoveAtTheBeginning()
    {
        //ARRANGE
        var randomNums = new Faker().Random;
        var list = Enumerable.Range(10, 20).Select(i => randomNums.Int(1, 9999))
        //!!.ToList() is important to materialize the Ienumerable collection !! ,
        //otherwhise the random generator will run
        //everytime returning different values everytime;
            .ToList();
        var ll = new SinglyLinkedList<int>(list);
        var expectedList = list.Skip(1).ToList();

        //ACT
        ll.Remove(list.First());

        //ASSERT
        ll.SequenceEqual(expectedList).Should().BeTrue();
    }

    [TestMethod]
    public void SinglyLinkedList_ShouldRemoveAtTheEnd()
    {
        //ARRANGE
        var randomNums = new Faker().Random;
        var list = Enumerable.Range(10, 20).Select(i => randomNums.Int(1, 9999))
        //!!.ToList() is important to materialize the Ienumerable collection !! ,
        //otherwhise the random generator will run
        //everytime returning different values everytime;
            .ToList();
        var ll = new SinglyLinkedList<int>(list);
        var expectedList = list[..^1];//range operator from 0 -> to list.Lenght-1 (0-th length not 1-th length)

        //ACT
        ll.Remove(list.Last());

        //ASSERT
        ll.SequenceEqual(expectedList).Should().BeTrue();
    }

    [TestMethod]
    public void SinglyLinkedList_ShouldRemoveSomewhereInTheMiddle()
    {
        //ARRANGE
        var randomNums = new Faker().Random;
        var list = Enumerable.Range(10, 20).Select(i => randomNums.Int(1, 9999))
        //!!.ToList() is important to materialize the Ienumerable collection !! ,
        //otherwhise the random generator will run
        //everytime returning different values everytime;
            .ToList();
        var ll = new SinglyLinkedList<int>(list);
        var expectedList = list[..];
        expectedList.RemoveAt(5);

        //ACT
        ll.Remove(list[5]);

        //ASSERT
        ll.SequenceEqual(expectedList).Should().BeTrue();
    }

    [TestMethod]
    public void SinglyLinkedList_ShouldFindAnItem()
    {
        //ARRANGE
        var randomNums = new Faker().Random;
        var list = Enumerable.Range(10, 20).Select(i => randomNums.Int(1, 9999))
        //!!.ToList() is important to materialize the Ienumerable collection !! ,
        //otherwhise the random generator will run
        //everytime returning different values everytime;
            .ToList();
        var ll = new SinglyLinkedList<int>(list);

        //ACT
        var uut = ll.FindItem(list.Skip(2).FirstOrDefault());

        //ASSERT
        uut.Should().Be(list.Skip(2).FirstOrDefault());
    }

    [TestMethod]
    public void SinglyLinkedList_WhenEmpty_ShouldReturnDefaultValue()
    {
        //ARRANGE
        var ll = new SinglyLinkedList<int>();

        //ACT
        var uut = ll.FindItem(99);

        //ASSERT
        uut.Should().Be(default);
    }

    [TestMethod]
    public void SinglyLinkedList_ShouldReverseList()
    {
        //ARRANGE
        var randomNums = new Faker().Random;
        var list = Enumerable.Range(10, 20).Select(i => randomNums.Int(1, 9999))
        //!!.ToList() is important to materialize the Ienumerable collection !! ,
        //otherwhise the random generator will run
        //everytime returning different values everytime;
            .ToList();

        //ACT
        var uut = new SinglyLinkedList<int>(list);
        uut.ReverseList();

        //ASSERT
        list.Reverse();
        uut.SequenceEqual(list).Should().BeTrue();
    }

    [TestMethod]
    public void SinglyLinkedList_ShouldAddElementAtBeginning()
    {
        //ARRANGE
        var randomNums = new Faker().Random;
        var list = Enumerable.Range(10, 20).Select(i => randomNums.Int(1, 9999))
        //!!.ToList() is important to materialize the Ienumerable collection !! ,
        //otherwhise the random generator will run
        //everytime returning different values everytime;
            .ToList();
        var uut = new SinglyLinkedList<int>(list);

        //ACT
        uut.AddAt(999, 0);

        //ASSERT
        uut[0].Should().Be(999);
    }

    [TestMethod]
    public void SinglyLinkedList_ShouldAddElementAtTheMiddle()
    {
        //ARRANGE
        var randomNums = new Faker().Random;
        var list = Enumerable.Range(10, 20).Select(i => randomNums.Int(1, 9999))
        //!!.ToList() is important to materialize the Ienumerable collection !! ,
        //otherwhise the random generator will run
        //everytime returning different values everytime;
            .ToList();
        var uut = new SinglyLinkedList<int>(list);

        //ACT
        uut.AddAt(999, 5);

        //ASSERT
        uut[5].Should().Be(999);
    }

    [TestMethod]
    public void SinglyLinkedList_ShouldAddElementAtTheEnd()
    {
        //ARRANGE
        var randomNums = new Faker().Random;
        var list = Enumerable.Range(10, 20).Select(i => randomNums.Int(1, 9999))
        //!!.ToList() is important to materialize the Ienumerable collection !! ,
        //otherwhise the random generator will run
        //everytime returning different values everytime;
            .ToList();
        var uut = new SinglyLinkedList<int>(list);

        //ACT
        uut.AddAt(999, 19);

        //ASSERT
        uut[19].Should().Be(999);
    }
}