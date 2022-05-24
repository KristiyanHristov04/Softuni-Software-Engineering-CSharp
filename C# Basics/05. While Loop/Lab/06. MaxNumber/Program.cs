using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //06. MaxNumber
            string input = Console.ReadLine();
            int maxNumber = int.MinValue;
            while (input != "Stop")
            {                
                if (maxNumber < Convert.ToInt32(input))
                {
                    maxNumber = Convert.ToInt32(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(maxNumber);
        }
    }
}
