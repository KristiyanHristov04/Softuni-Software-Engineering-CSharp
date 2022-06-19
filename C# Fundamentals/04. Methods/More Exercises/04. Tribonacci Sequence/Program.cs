using System;

namespace _04._Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            Tribonacci(num);
        }
        static void Tribonacci(int num)
        {
            int[] arr = new int[num];
            for (int i = 0; i < num; i++)
            {
                if (i == 0)
                {
                    arr[i] = 1;
                }
                else if (i == 1)
                {
                    arr[i] = 1;
                }
                else if (i == 2)
                {
                    arr[i] = arr[i - 1] + arr[i - 2];
                }
                else
                {
                    arr[i] = arr[i - 1] + arr[i - 2] + arr[i - 3];
                }
            }
            Console.WriteLine(String.Join(" ", arr));
        }
    }
}
