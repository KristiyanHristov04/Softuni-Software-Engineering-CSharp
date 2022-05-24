using System;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            //05. Account Balance
            string input = Console.ReadLine();
            double sum = 0;
            while (input != "NoMoreMoney")
            {
                
                
                if (Convert.ToDouble(input) < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                sum += Convert.ToDouble(input);
                Console.WriteLine($"Increase: {Convert.ToDouble(input):f2}");
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
