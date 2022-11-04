using System;

namespace _04._Sum_of_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(' ');
            int totalSum = 0;

            for (int i = 0; i < elements.Length; i++)
            {
                try
                {
                    int currentElement = Convert.ToInt32(elements[i]);
                    totalSum += currentElement;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{elements[i]}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{elements[i]}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{elements[i]}' processed - current sum: {totalSum}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {totalSum}");
        }
    }
}
