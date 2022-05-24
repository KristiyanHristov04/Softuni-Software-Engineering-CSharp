using System;

namespace Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            //03. Sum Prime Non Prime
            // 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79,
            // 83, 89, 97, 101, 103, 107, 109, 113,
            
            string input = Console.ReadLine();

            int primeNumSum = 0;
            int nonPrimeNumSum = 0;
            bool isPrime;
            
            while (input != "stop")
            {
                int number = Convert.ToInt32(input);
                isPrime = true;
                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    for (int i = 2; i < number; i++)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                            nonPrimeNumSum += number;
                            break;
                        }
                    }
                    if (isPrime == true)
                    {
                        primeNumSum += number;
                    }
                }                             
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeNumSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNumSum}");
            
        }
    }
}
