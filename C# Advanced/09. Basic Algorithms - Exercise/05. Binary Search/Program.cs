using System;
using System.Linq;

namespace _05._Binary_Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            BinarySearch search = new BinarySearch();
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int key = Convert.ToInt32(Console.ReadLine());
            int foundIndex = search.IndexOf(arr, key);
            Console.WriteLine($"{foundIndex}");
        }
        public class BinarySearch
        {
            public int IndexOf(int[] arr, int key)
            {
                int leftBound = 0;
                int rightBound = arr.Length - 1;
                while (leftBound <= rightBound)
                {
                    int mid = leftBound + (rightBound - leftBound) / 2;
                    if (key < arr[mid])
                    {
                        rightBound = mid - 1;
                    }
                    else if (key > arr[mid])
                    {
                        leftBound = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }
                return -1;
            }
        }
    }
}
