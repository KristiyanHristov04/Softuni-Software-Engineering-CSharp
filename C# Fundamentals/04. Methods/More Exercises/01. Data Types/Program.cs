using System;

namespace _01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Result(number));
            }
            else if(type == "real")
            {
                double number = Convert.ToDouble(Console.ReadLine());
                double result = Result(number);
                Console.WriteLine($"{result:f2}");
            }
            else if (type == "string")
            {
                string text = Console.ReadLine();
                Console.WriteLine(Result(text));
            }
        }
        static int Result(int number)
        {
            int result = number * 2;
            return result;
        }
        static double Result(double number)
        {
            double result = number * 1.5;
            return result;
        }
        static string Result(string text)
        {
            return "$" + text + "$";
        }
    }
}
