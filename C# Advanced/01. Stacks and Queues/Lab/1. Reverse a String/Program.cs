using System;
using System.Collections.Generic;
namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                stack.Push(chars[i].ToString());
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
