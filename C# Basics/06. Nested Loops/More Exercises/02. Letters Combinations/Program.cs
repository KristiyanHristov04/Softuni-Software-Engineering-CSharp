using System;

namespace _02._Letters_Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letterFirst = char.Parse(Console.ReadLine());
            char letterLast = char.Parse(Console.ReadLine());
            char letterMissed = char.Parse(Console.ReadLine());

            int count = 0;

            for (char i = letterFirst; i <= letterLast; i++)
            {
                for (char j = letterFirst; j <= letterLast; j++)
                {
                    for (char m = letterFirst; m <= letterLast; m++)
                    {
                        if (i == letterMissed || j == letterMissed || m == letterMissed)
                        {
                            continue;
                        }
                        else
                        {
                            count++;
                            Console.Write($"{i}{j}{m} ");
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
