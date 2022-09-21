using System;
using System.Linq;
namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList<int> list = new CustomDoublyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            Console.WriteLine(list.Length());
            Console.WriteLine(list.RemoveLast());
            Console.WriteLine(list.RemoveFirst());
            list.AddFirst(10);
            list.AddFirst(5);
            list.AddFirst(24);
            list.ForEach(x => Console.WriteLine(x));
            int[] array = list.ToArray();
            Predicate<int> predicate = number => number % 2 == 0;
            array = array.Where(number => predicate(number)).ToArray();
            Console.WriteLine("All even numbers in the doubly linked list:");
            foreach (var number in array)
            {
                Console.WriteLine(number);
            }
        }
    }
}
