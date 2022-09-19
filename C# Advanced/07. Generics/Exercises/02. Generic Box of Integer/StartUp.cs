using System;

namespace _02._Generic_Box_of_Integer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                var box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}
