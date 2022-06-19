using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] commands = input.Split();
                int number = int.Parse(commands[1]);
                switch (commands[0])
                {
                    case "Add":                       
                        list.Add(number);
                        break;
                    case "Remove":
                        list.Remove(number);
                        break;
                    case "RemoveAt":
                        list.RemoveAt(number);
                        break;
                    case "Insert":
                        int index = int.Parse(commands[2]);
                        list.Insert(index, number);
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
