using System;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            list.Add(5);
            list.Add(50);
            list.Add(500);
            list.Add(5000);
            Console.WriteLine(String.Join(", ", list));
            list.Swap(1, 2);
            Console.WriteLine(String.Join(", ", list));
            Console.WriteLine(list.Contains(50));
            list.RemoveAt(2);
            Console.WriteLine(list.Contains(50));
            Console.WriteLine(String.Join(", ", list));
            list.Insert(3, 50000);
            Console.WriteLine(String.Join(", ", list));
        }
    }
}
