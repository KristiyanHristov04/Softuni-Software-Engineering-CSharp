using System;

namespace Unique_Pin_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Unique Pin Codes
            int firstBorder = int.Parse(Console.ReadLine()); 
            int secondBorder = int.Parse(Console.ReadLine()); 
            int thirdBorder = int.Parse(Console.ReadLine()); 

            for (int i = 2; i <= firstBorder; i += 2)
            {
                for (int j = 2; j <= secondBorder; j++)
                {
                    if (j == 2 || j == 3 || j == 5 || j == 7)
                    {
                        for (int k = 2; k <= thirdBorder; k += 2)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}
  

