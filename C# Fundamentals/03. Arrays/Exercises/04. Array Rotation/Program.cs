using System;
using System.Linq;

namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numberOfRotations = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfRotations; i++)
            {
                int arrayLength = array.Length;
                int firstNumber = array[0];
                for (int j = 0; j < array.Length; j++)
                {
                    
                    if (j + 1 < arrayLength)
                    {
                        array[j] = array[j + 1];
                    }
                    else if(j + 1 >= arrayLength)
                    {
                        array[arrayLength - 1] = firstNumber;
                    }
                }
            }
            foreach (var number in array)
            {
                Console.Write(number + " ");
            }
        }
    }
}
