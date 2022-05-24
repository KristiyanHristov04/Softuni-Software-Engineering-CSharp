using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            //07. Moving
            int freeSpaceWidth = Convert.ToInt32(Console.ReadLine());
            int freeSpaceLength = Convert.ToInt32(Console.ReadLine());
            int freeSpaceHeigth = Convert.ToInt32(Console.ReadLine());
            int totalFreeSpace = freeSpaceHeigth * freeSpaceWidth * freeSpaceLength;
            bool isValid = true;
            while (totalFreeSpace > 0)
            {
                string input = Console.ReadLine();
                
                if (input == "Done")
                {
                    isValid = false;
                    break;
                }
                totalFreeSpace -= Convert.ToInt32(input);
                if (totalFreeSpace < 0)
                {
                    break;
                }
            }
            if (totalFreeSpace > 0 && isValid == false)
            {
                Console.WriteLine($"{totalFreeSpace} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need { Math.Abs(totalFreeSpace) } Cubic meters more.");
            }
        }
    }
}
