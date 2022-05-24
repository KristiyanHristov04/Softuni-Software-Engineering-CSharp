using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            //06. Cake
            int cakeWidth = Convert.ToInt32(Console.ReadLine());
            int cakeLength = Convert.ToInt32(Console.ReadLine());
            int totalPieces = cakeWidth * cakeLength;
            bool IsValid = true;
            while (totalPieces > 0)
            {
                string input = Console.ReadLine();
                if (input == "STOP")
                {
                    IsValid = false;
                    break;
                }
                totalPieces -= Convert.ToInt32(input);
                if(totalPieces < 0)
                {
                    break;
                }
            }
            if (IsValid == false)
            {
                Console.WriteLine($"{totalPieces} pieces are left.");
            }
            else if(totalPieces < 0)
            {
                
                Console.WriteLine($"No more cake left! You need { Math.Abs(totalPieces)} pieces more.");
            }

        }
    }
}
