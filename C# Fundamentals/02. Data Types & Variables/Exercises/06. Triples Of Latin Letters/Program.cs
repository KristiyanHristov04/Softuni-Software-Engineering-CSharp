using System;

namespace Triples_Of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (char i = 'a'; i < 'a' + n; i++)
            {
                for (char k = 'a'; k < 'a' + n; k++)
                {
                    for (char l = 'a'; l < 'a' + n; l++)
                    {
                        Console.WriteLine($"{i}{k}{l}");
                    }

                }
            }
        }
    }
}
