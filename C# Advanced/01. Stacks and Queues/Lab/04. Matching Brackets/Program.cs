using System;
using System.Collections.Generic;
namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '(')
                {
                    stack.Push(i);
                }
                else if(c == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    string subExrpession = input.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(subExrpession);
                }
            }

        }
    }
}
