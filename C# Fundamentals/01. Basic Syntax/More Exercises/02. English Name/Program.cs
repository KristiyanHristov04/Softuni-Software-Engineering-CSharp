using System;

namespace English_Name_of_The_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            //02. English name of the last digit
            string input = Console.ReadLine();
            int i = 0;
            string a = "";
            for (i = 0; i < input.Length; i++)
            {
                a = input[i].ToString();
            }
            //Console.WriteLine(a);
            if (a == "0")
            {
                Console.WriteLine("zero");
            }
            else if (a == "1")
            {
                Console.WriteLine("one");
            }
            else if (a == "2")
            {
                Console.WriteLine("two");
            }
            else if (a == "3")
            {
                Console.WriteLine("three");
            }
            else if (a == "4")
            {
                Console.WriteLine("four");
            }
            else if (a == "5")
            {
                Console.WriteLine("five");
            }
            else if (a == "6")
            {
                Console.WriteLine("six");
            }
            else if (a == "7")
            {
                Console.WriteLine("seven");
            }
            else if (a == "8")
            {
                Console.WriteLine("eight");
            }
            else if (a == "9")
            {
                Console.WriteLine("nine");
            }
            else if (a == "10")
            {
                Console.WriteLine("ten");
            }

        }
    }
}
