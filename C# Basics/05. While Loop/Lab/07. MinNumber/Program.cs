using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //07. Min Number
            string input = Console.ReadLine();
            int minNumber = int.MaxValue;
            while (input != "Stop")
            {
                if (minNumber > Convert.ToInt32(input))
                {
                    minNumber = Convert.ToInt32(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(minNumber);
        }
    }
}


    
