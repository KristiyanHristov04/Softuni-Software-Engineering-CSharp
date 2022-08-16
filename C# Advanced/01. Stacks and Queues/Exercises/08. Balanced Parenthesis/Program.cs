using System;
using System.Linq;
using System.Collections.Generic;
namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> openBrackets = new Stack<char>();
            bool isBalanced = false;

            foreach (var bracket in input)
            {
                if (bracket == '(' || bracket == '{' || bracket == '[')
                {
                    openBrackets.Push(bracket);
                }
                else if (bracket == ')' || bracket == '}' || bracket == ']')
                {

                    if (openBrackets.Count <= 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    char lastOpen = openBrackets.Pop();
                    if (lastOpen == '{' && bracket == '}')
                    {
                        isBalanced = true;
                    }
                    else if (lastOpen == '(' && bracket == ')')
                    {
                        isBalanced = true;
                    }
                    else if (lastOpen == '[' && bracket == ']')
                    {
                        isBalanced = true;
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
