using System;

namespace _06._Bubble_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bubble Sort -> The Bubble Sort algorithm is STABLE!
            int[] array = new int[] { 20, 42, 14, 37, 4, 33, 50, 10, 36, 19, 40, 13, 24, 34, 49 };
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (i + 1 < array.Length && array[i] > array[i + 1])
                    {
                        isSorted = false;
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
            Console.WriteLine(String.Join(" ", array));
        }
    }
}
