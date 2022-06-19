using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startPos = Convert.ToChar(Console.ReadLine());
            char endPos = Convert.ToChar(Console.ReadLine());
            Print(startPos, endPos);
        }
        static void Print(char start, char end)
        {
            if (start > end)
            {
                char temp = start;
                start = end;
                end = temp;
            }
            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
