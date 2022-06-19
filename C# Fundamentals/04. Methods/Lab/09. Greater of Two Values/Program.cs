using System;

namespace _09._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(GetMax(a, b));
            }
            else if(type == "char")
            {
                char a = Convert.ToChar(Console.ReadLine());
                char b = Convert.ToChar(Console.ReadLine());
                Console.WriteLine(GetMax(a, b));
            }
            else if(type == "string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                Console.WriteLine(GetMax(a, b));
            }
        }
        static int GetMax(int a, int b)
        {
            int result = 0;
            if (a > b)
            {
                result = a;
            }
            else if(b > a)
            {
                result = b;
            }            
            return result;
        }

        static char GetMax(char a, char b)
        {
            char result = '0';
            if (a > b)
            {
                result = a;
            }
            else if (b > a)
            {
                result = b;
            }

            return result;
        }

        static string GetMax(string a, string b)
        {
            int comparison = a.CompareTo(b);
            string result = "";
            if (comparison > 0)
            {
                result = a;
            }
            else
            {
                result = b;
            }
            return result;
        }
    }
}
