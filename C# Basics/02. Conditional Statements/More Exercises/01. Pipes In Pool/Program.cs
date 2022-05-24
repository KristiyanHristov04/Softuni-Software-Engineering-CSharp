using System;

namespace SoftUniConditionalStatementsMoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            int poolCapacity = Convert.ToInt32(Console.ReadLine());
            int pipe01PerHour = Convert.ToInt32(Console.ReadLine());
            int pipe02PerHour = Convert.ToInt32(Console.ReadLine());
            double hours = Convert.ToDouble(Console.ReadLine());

            double total = pipe01PerHour * hours + pipe02PerHour * hours;
            double totalInPercent = total / poolCapacity * 100;

            double pipe01InPercentFull = (pipe01PerHour * hours) / total * 100;
            double pipe02InPercentFull = (pipe02PerHour * hours) / total * 100;

            double pipe01InLitres = (hours * pipe01PerHour);
            double pipe02InLitres = (hours * pipe02PerHour);
            double overflow = (pipe01InLitres + pipe02InLitres) - poolCapacity;

            if (total <= poolCapacity)
            {
                Console.WriteLine($"The pool is {totalInPercent:f2}% full. Pipe 1: {pipe01InPercentFull:f2}%. Pipe 2: {pipe02InPercentFull:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {hours:f2} hours the pool overflows with {overflow:f2} liters.");
            }

        }
    }
}

