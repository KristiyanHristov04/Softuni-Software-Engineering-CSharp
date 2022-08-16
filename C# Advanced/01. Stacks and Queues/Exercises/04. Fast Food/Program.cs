using System;
using System.Collections.Generic;
using System.Linq;
namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = Convert.ToInt32(Console.ReadLine());
            int[] orders = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                int currentOrderQuantity = queue.Peek();
                if (currentOrderQuantity > quantityOfFood)
                {
                    break;
                }
                quantityOfFood -= currentOrderQuantity;
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine("Orders left: " + String.Join(" ", queue));
            }
        }
    }
}
