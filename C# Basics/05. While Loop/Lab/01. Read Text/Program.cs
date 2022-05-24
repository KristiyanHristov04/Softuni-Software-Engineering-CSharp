using System;

namespace SoftUniWhileLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            //01. Read Text
            string text = Console.ReadLine();
            while (text != "Stop")
            {
                Console.WriteLine(text);
                text = Console.ReadLine();
            }
        }
    }
}
