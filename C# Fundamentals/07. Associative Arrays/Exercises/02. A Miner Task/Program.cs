using System;
using System.Collections.Generic;
namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            while (true)
            {
                string resources = Console.ReadLine();
                if (resources == "stop")
                {
                    break;
                }

                int quantity = Convert.ToInt32(Console.ReadLine());

                if (result.ContainsKey(resources))
                {
                    result[resources] += quantity;
                }
                else
                {
                    result.Add(resources, quantity);
                }
            }

            foreach (var resource in result)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
