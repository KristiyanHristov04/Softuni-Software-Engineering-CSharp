using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            bool appliedChanges = false;
            while (input != "end")
            {
                string[] commands = input.Split();
                int number = 0;
                
                switch (commands[0])
                {
                    case "Add":
                        number = int.Parse(commands[1]);
                        list.Add(number);
                        appliedChanges = true;
                        break;
                    case "Remove":
                        number = int.Parse(commands[1]);
                        list.Remove(number);
                        appliedChanges = true;
                        break;
                    case "RemoveAt":
                        number = int.Parse(commands[1]);
                        list.RemoveAt(number);
                        appliedChanges = true;
                        break;
                    case "Insert":
                        number = int.Parse(commands[1]);
                        int index = int.Parse(commands[2]);
                        list.Insert(index, number);
                        appliedChanges = true;
                        break;
                    case "Contains":
                        number = int.Parse(commands[1]);
                        if (list.Contains(number))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "PrintOdd":
                        List<int> oddNumbers = new List<int>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] % 2 != 0)
                            {
                                oddNumbers.Add(list[i]);
                            }
                        }
                        Console.WriteLine(String.Join(" ", oddNumbers));
                        break;

                    case "PrintEven":
                        List<int> evenNumbers = new List<int>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] % 2 == 0)
                            {
                                evenNumbers.Add(list[i]);
                            }
                        }
                        Console.WriteLine(String.Join(" ", evenNumbers));
                        break;
                    case "GetSum":
                        int sum = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            sum += list[i];
                        }
                        Console.WriteLine(sum);
                        break;
                    case "Filter":
                        string filter = commands[1];
                        int numberFilter = int.Parse(commands[2]);
                        List<int> condition = new List<int>();
                        switch (filter)
                        {
                            case ">=":                               
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i] >= numberFilter)
                                    {
                                        condition.Add(list[i]);
                                    }
                                }
                                Console.WriteLine(String.Join(" ", condition));
                                break;
                            case "<=":
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i] <= numberFilter)
                                    {
                                        condition.Add(list[i]);
                                    }
                                }
                                Console.WriteLine(String.Join(" ", condition));
                                break;
                            case ">":
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i] > numberFilter)
                                    {
                                        condition.Add(list[i]);
                                    }
                                }
                                Console.WriteLine(String.Join(" ", condition));
                                break;
                            case "<":
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i] < numberFilter)
                                    {
                                        condition.Add(list[i]);
                                    }
                                }
                                Console.WriteLine(String.Join(" ", condition));
                                break;                                
                        }                       
                        break;                        
                }
                input = Console.ReadLine();
            }
            if (appliedChanges)
            {
                Console.WriteLine(String.Join(" ", list));
            }
        }
    }
}
