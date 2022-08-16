using System;
using System.Collections.Generic;
using System.Linq;
namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int firstNumber = Convert.ToInt32(stack.Pop());
                char operation = Convert.ToChar(stack.Pop());
                int secondNumber = Convert.ToInt32(stack.Pop());

                if (operation == '+')
                {
                    stack.Push(Convert.ToString(firstNumber + secondNumber));
                }
                else if(operation == '-')
                {
                    stack.Push(Convert.ToString(firstNumber - secondNumber));
                }
            }

            Console.WriteLine(stack.Peek());
            
        }
    }
}
