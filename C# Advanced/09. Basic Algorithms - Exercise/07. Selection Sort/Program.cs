using System;

namespace _07._Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Selection Sort -> The Selection Sort algorithm is UNSTABLE!
            int[] array = new int[] { 36, 48, 39, 21, 26, 19, 5, 3, 39, 27 };    
            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];
                int smallestNumber = int.MaxValue;
                int index = -1;
                if (i + 1 >= array.Length)
                {
                    break;
                }
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (smallestNumber > array[j])
                    {
                        index = j;
                        smallestNumber = array[j];
                    }
                }
                if (currentNumber > smallestNumber)
                {
                    array[i] = smallestNumber;
                    array[index] = currentNumber;
                }
            }
            Console.WriteLine(String.Join(" ", array));
        }
    }
}
