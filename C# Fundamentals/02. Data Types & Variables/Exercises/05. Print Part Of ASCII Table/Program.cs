using System;

namespace Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startPos = Convert.ToInt32(Console.ReadLine());
            int endPos = Convert.ToInt32(Console.ReadLine());
            for (int i = startPos; i <= endPos; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
