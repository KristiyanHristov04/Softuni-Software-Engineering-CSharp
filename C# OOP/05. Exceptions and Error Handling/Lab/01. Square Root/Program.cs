using System;

namespace _01._Square_Root
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
