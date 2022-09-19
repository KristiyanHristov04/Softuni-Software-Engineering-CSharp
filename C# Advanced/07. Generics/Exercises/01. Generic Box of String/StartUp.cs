using System;

namespace _01._Generic_Box_of_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfStrings = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfStrings; i++)
            {
                string input = Console.ReadLine();
                var box = new Box<string>(input);
                Console.WriteLine(box);
            }
        }
    }
}
