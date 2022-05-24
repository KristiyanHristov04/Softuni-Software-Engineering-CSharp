using System;

namespace Number100_200
{
    class Program
    {
        static void Main(string[] args)
        {
            int enterNumber = Convert.ToInt32(Console.ReadLine());
            if (enterNumber < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (enterNumber >= 100 && enterNumber <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else if (enterNumber > 200)
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}

