using System;

namespace Print_And_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNum = Convert.ToInt32(Console.ReadLine());
            int endNum = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = startNum; i <= endNum; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
