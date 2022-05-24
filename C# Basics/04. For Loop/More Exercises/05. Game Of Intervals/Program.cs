using System;

namespace Game_Of_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            //05. Game Of Intervals
            int numberOfMovesInGame = Convert.ToInt32(Console.ReadLine());//Колко хода ще има
                                                                          //по време на играта
            double startingPoints = 0;
            double invalidNumbers = 0;
            double numbersFrom0to9 = 0;
            double numbersFrom10to19 = 0;
            double numbersFrom20to29 = 0;
            double numbersFrom30to39 = 0;
            double numbersFrom40to50 = 0;


            for (int i = 0; i < numberOfMovesInGame; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (number >= 0 && number <= 9)
                {
                    startingPoints += number * 2 / 10.0;
                    numbersFrom0to9++;
                }
                else if (number >= 10 && number <= 19)
                {
                    startingPoints += number * 3 / 10.0;
                    numbersFrom10to19++;
                }
                else if (number >= 20 && number <= 29)
                {
                    startingPoints += number * 4 / 10.0;
                    numbersFrom20to29++;
                }
                else if (number >= 30 && number <= 39)
                {
                    startingPoints += 50;
                    numbersFrom30to39++;
                }
                else if (number >= 40 && number <= 50)
                {
                    startingPoints += 100;
                    numbersFrom40to50++;
                }
                else
                {
                    startingPoints /= 2;
                    invalidNumbers++;
                }
            }
            Console.WriteLine($"{startingPoints:f2}");
            Console.WriteLine($"From 0 to 9: {numbersFrom0to9 / numberOfMovesInGame * 100:f2}%");
            Console.WriteLine($"From 10 to 19: {numbersFrom10to19 / numberOfMovesInGame * 100:f2}%");
            Console.WriteLine($"From 20 to 29: {numbersFrom20to29 / numberOfMovesInGame * 100:f2}%");
            Console.WriteLine($"From 30 to 39: {numbersFrom30to39 / numberOfMovesInGame * 100:f2}%");
            Console.WriteLine($"From 40 to 50: {numbersFrom40to50 / numberOfMovesInGame * 100:f2}%");
            Console.WriteLine($"Invalid numbers: {invalidNumbers / numberOfMovesInGame * 100:f2}%");

        }       
    }
}
