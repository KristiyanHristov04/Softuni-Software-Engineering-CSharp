using System;

namespace Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int openingBrackets = 0;
            int closingBrackets = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if(input == ")")
                {
                    closingBrackets++;
                    if (openingBrackets - closingBrackets != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
                else if(input == "(")
                {
                    openingBrackets++;
                }
            }

            if (openingBrackets == closingBrackets)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
