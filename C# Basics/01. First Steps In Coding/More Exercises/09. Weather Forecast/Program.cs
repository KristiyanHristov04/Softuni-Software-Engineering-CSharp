using System;

namespace exercise10
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Convert.ToString(Console.ReadLine());
            if (word.ToLower() == "sunny")
            {
                Console.WriteLine("It's warm outside!");
            }
            else
            {
                Console.WriteLine("It's cold outside!");
            }
        }
    }
}

