using System;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] ladyBugsField = new int[fieldSize]; 

            string[] occupiedIndexes = Console.ReadLine().Split(); 

            for (int i = 0; i < occupiedIndexes.Length; i++)
            {
                int currentIndex = int.Parse(occupiedIndexes[i]);
                if (currentIndex >= 0 && currentIndex < fieldSize)
                {
                    ladyBugsField[currentIndex] = 1; 
                }
            }

            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                bool isFirst = true;
                int currentIndex = int.Parse(commands[0]);
                while (currentIndex >= 0 && currentIndex < fieldSize && ladyBugsField[currentIndex] != 0)
                {
                    if (isFirst)
                    {
                        ladyBugsField[currentIndex] = 0;
                        isFirst = false;
                    }

                    string direction = commands[1];
                    int flightLenght = int.Parse(commands[2]);
                    if (direction == "left")
                    {
                        currentIndex -= flightLenght;
                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladyBugsField[currentIndex] == 0)
                            {
                                ladyBugsField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        currentIndex += flightLenght;
                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladyBugsField[currentIndex] == 0)
                            {
                                ladyBugsField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", ladyBugsField));
        }
    }
}