using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commands = input.Split(' ');                
                switch (commands[0])
                {
                    case "Add":
                        int numberToAdd = Convert.ToInt32(commands[1]);
                        numbers.Add(numberToAdd);
                        break;
                    case "Insert":
                        int number = Convert.ToInt32(commands[1]);
                        int index = Convert.ToInt32(commands[2]);
                        if (numbers.Count > index && index >= 0)
                        {
                            numbers.Insert(index, number);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }                       
                        break;
                    case "Remove":
                        int removeNumberAtIndex = Convert.ToInt32(commands[1]);
                        if (numbers.Count > removeNumberAtIndex && removeNumberAtIndex >= 0)
                        {
                            numbers.RemoveAt(removeNumberAtIndex);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Shift":
                        if (commands[1] == "left")
                        {
                            int count = Convert.ToInt32(commands[2]);
                            for (int i = 0; i < count; i++)
                            {
                                int firstNumber = numbers[0];
                                numbers.Remove(numbers[0]);
                                numbers.Add(firstNumber);
                            }
                        }
                        else if (commands[1] == "right")
                        {
                            int count = Convert.ToInt32(commands[2]);
                            for (int i = 0; i < count; i++)
                            {
                                int lastNumber = numbers[numbers.Count - 1];
                                numbers.Remove(numbers[numbers.Count - 1]);
                                numbers.Insert(0, lastNumber);
                            }
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
