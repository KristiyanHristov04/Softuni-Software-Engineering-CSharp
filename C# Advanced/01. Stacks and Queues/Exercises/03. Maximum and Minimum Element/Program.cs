using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] query = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (query.Length == 2)
                {
                    int numberToPush = query[1];
                    stack.Push(numberToPush);
                }
                else if (query.Length == 1)
                {
                    int number = query[0];
                    switch (number)
                    {
                        case 2:
                            if (stack.Count > 0)
                            {
                                stack.Pop();
                            }  
                            break;

                        case 3:
                            if (stack.Count > 0)
                            {
                                Console.WriteLine(stack.Max());
                            }
                            break;

                        case 4:
                            if (stack.Count > 0)
                            {
                                Console.WriteLine(stack.Min());
                            }
                            break;
                    }
                }
            }
            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
