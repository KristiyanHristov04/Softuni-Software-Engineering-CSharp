using System;

namespace SoftuniExercices1
{
    class Program
    {
        static void Main(string[] args)
        {
            double dogFood = 2.50;
            int catFood = 4;

            int numberOfPacketsForDogFood = Convert.ToInt32(Console.ReadLine());
            int numberOfPacketsForCatFood = Convert.ToInt32(Console.ReadLine());

            double total = numberOfPacketsForDogFood * dogFood + numberOfPacketsForCatFood * catFood;
            Console.WriteLine($"{total} lv.");



        }
    }
}
