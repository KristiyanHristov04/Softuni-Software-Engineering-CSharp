using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Generic_Swap_Method_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }

            var box = new Box<string>(list);
            int[] indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            box.Swap(list, indexes[0], indexes[1]);
            Console.WriteLine(box);

        }
    }
}
