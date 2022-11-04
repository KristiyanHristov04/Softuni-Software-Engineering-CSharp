using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int exceptionsCounter = 0;

            while (exceptionsCounter < 3)
            {
                string[] input = Console.ReadLine().Split();
                try
                {
                    switch (input[0])
                    {
                        case "Replace":
                            int index = Convert.ToInt32(input[1]);
                            int element = Convert.ToInt32(input[2]);
                            array[index] = element;
                            break;
                        case "Show":
                            index = Convert.ToInt32(input[1]);
                            Console.WriteLine(array[index]);
                            break;
                        case "Print":
                            int startIndex = Convert.ToInt32(input[1]);
                            int endIndex = Convert.ToInt32(input[2]);
                            List<int> temp = new List<int>();
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                temp.Add(array[i]);
                            }
                            Console.WriteLine(String.Join(", ", temp));
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCounter++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCounter++;
                }
            }
            Console.WriteLine(String.Join(", ", array));
        }
    }
}
