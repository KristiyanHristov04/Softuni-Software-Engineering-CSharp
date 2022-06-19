using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] commands = input.Split(' ');
                switch (commands[0])
                {
                    case "Delete":
                        int specificElement = Convert.ToInt32(commands[1]);
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] == specificElement)
                            {
                                list.Remove(list[i]);
                                i--;
                            }
                        }
                        break;
                    case "Insert":
                        int elementToInsert = Convert.ToInt32(commands[1]);
                        int index = Convert.ToInt32(commands[2]);
                        list.Insert(index, elementToInsert);
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
