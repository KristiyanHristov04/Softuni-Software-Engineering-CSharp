using System;
using System.Linq;
using System.Collections.Generic;
namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] info = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                queue.Enqueue(info);
            }

            int startIndex = 0;

            while (true)
            {
                bool isCompleted = true;
                int totalLiters = 0;

                foreach (int[] array in queue)
                {
                    int liters = array[0];
                    int distance = array[1];

                    totalLiters += liters;

                    if (totalLiters - distance >= 0)
                    {
                        totalLiters -= distance;
                    }
                    else
                    {
                        int[] currentPump = queue.Dequeue();
                        queue.Enqueue(currentPump);
                        startIndex++;
                        isCompleted = false;
                        break;
                    }
                }
                if (isCompleted)
                {
                    Console.WriteLine(startIndex);
                    return;
                }
            }
        }
    }
}
