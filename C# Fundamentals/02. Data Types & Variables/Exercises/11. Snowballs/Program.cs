using System;
using System.Numerics;
namespace Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int madeSnowballs = Convert.ToInt32(Console.ReadLine());
            BigInteger bestSnowballValue = 0;
            int bestSnowballValueQuality = 0;
            int bestSnowballValueTime = 0;
            int bestSnowballValueSnow = 0;

            int snow = 0;
            int time = 0;
            int quality = 0;
            for (int i = 1; i <= madeSnowballs; i++)
            {
                snow = Convert.ToInt32(Console.ReadLine());
                time = Convert.ToInt32(Console.ReadLine());
                quality = Convert.ToInt32(Console.ReadLine());
                BigInteger currentSnowballValue = BigInteger.Pow(snow / time, quality); // tuka trqbva da se izpolzva po golqma merna edinica zashtoto nadvishava
                if (currentSnowballValue > bestSnowballValue)
                {
                    bestSnowballValue = currentSnowballValue;
                    bestSnowballValueQuality = quality;
                    bestSnowballValueTime = time;
                    bestSnowballValueSnow = snow;
                }
            }
            Console.WriteLine($"{bestSnowballValueSnow} : {bestSnowballValueTime} = {bestSnowballValue} ({bestSnowballValueQuality})");
        }
            
    }
}
