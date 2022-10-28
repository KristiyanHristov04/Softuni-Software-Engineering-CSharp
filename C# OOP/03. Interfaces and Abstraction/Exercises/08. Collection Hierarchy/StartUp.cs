using System;

namespace CollectionHierarchy
{
    using Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection removeCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int removeOperations = Convert.ToInt32(Console.ReadLine());

            foreach (var word in input)
            {
                Console.Write(addCollection.Add(word) + " "); 
            }
            Console.WriteLine();

            foreach (var word in input)
            {
                Console.Write(removeCollection.Add(word) + " ");
            }
            Console.WriteLine();

            foreach (var word in input)
            {
                Console.Write(myList.Add(word) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write(removeCollection.Remove() + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
            Console.WriteLine();
        }
    }
}
