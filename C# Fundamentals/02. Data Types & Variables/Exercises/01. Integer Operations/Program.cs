using System;

namespace Data_Types_and_Variables___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num01 = Convert.ToInt32(Console.ReadLine());
            int num02 = Convert.ToInt32(Console.ReadLine());
            int num03 = Convert.ToInt32(Console.ReadLine());
            int num04 = Convert.ToInt32(Console.ReadLine());

            int result = ((num01 + num02) / num03) * num04;
            Console.WriteLine(result);
        }
    }
}
