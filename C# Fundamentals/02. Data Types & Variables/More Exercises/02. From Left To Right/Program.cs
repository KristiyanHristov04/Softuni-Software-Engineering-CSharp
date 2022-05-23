using System;
using System.Linq;

namespace From_Left_To_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solution 1(Judge doesn't really like it):
            //long n = Convert.ToInt32(Console.ReadLine());
            //long sum = 0;
            //long[] numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();
            //for (int i = 1; i <= n; i++)
            //{
            //    long leftNumber = numbers[0];
            //    long rightNumber = numbers[1];
            //    if (leftNumber > rightNumber)
            //    {
            //        string leftNumberStringed = leftNumber.ToString();
            //        for (int j = 0; j < leftNumberStringed.Length; j++)
            //        {
            //            sum += leftNumberStringed[j] - '0';
            //        }
            //    }
            //    else if (leftNumber < rightNumber)
            //    {
            //        string rightNumberStringed = rightNumber.ToString();
            //        for (int k = 0; k < rightNumberStringed.Length; k++)
            //        {
            //            sum += rightNumberStringed[k] - '0';
            //        }
            //    }
            //    else if (leftNumber == rightNumber)
            //    {
            //        string leftNumberStringed = leftNumber.ToString();
            //        for (int l = 0; l < leftNumberStringed.Length; l++)
            //        {
            //            sum += leftNumberStringed[l] - '0';
            //        }
            //    }
            //    Console.WriteLine(Math.Abs(sum));
            //    if (i < n)
            //    {
            //        numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();
            //        sum = 0;
            //    }
            //}

            //Solution 2(Judge doesn't really like it):
            //int n = Convert.ToInt32(Console.ReadLine());
            //int sum01 = 0;
            //int sum02 = 0;
            //string numbers = Console.ReadLine();
            //bool isSpaceMet = false;
            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 0; j < numbers.Length; j++)
            //    {
            //        if (numbers[j] == ' ')
            //        {
            //            isSpaceMet = true;
            //            j++;
            //        }

            //        if (!isSpaceMet)
            //        {
            //            sum01 += numbers[j] - '0';
            //        }
            //        else if (isSpaceMet)
            //        {
            //            sum02 += numbers[j] - '0';
            //        }
            //    }

            //    if (sum01 > sum02)
            //    {
            //        Console.WriteLine(Math.Abs(sum01));
            //    }
            //    else if (sum01 < sum02)
            //    {
            //        Console.WriteLine(Math.Abs(sum02));
            //    }
            //    else if (sum01 == sum02)
            //    {
            //        Console.WriteLine(Math.Abs(sum01));
            //    }

            //    if (i < n)
            //    {
            //        numbers = Console.ReadLine();
            //        sum01 = 0;
            //        sum02 = 0;
            //        isSpaceMet = false;
            //    }
            //}

            //int n = int.Parse(Console.ReadLine());

            //for (int i = 0; i < n; i++)
            //{
            //    string numbers = Console.ReadLine();
            //    char delimiter = ' ';
            //    string[] splitNumbers = numbers.Split(delimiter);

            //    long leftNum = long.Parse(splitNumbers[0]);
            //    long rightNum = long.Parse(splitNumbers[1]);

            //    long biggerNumber = rightNum;
            //    if (leftNum > rightNum)
            //    {
            //        biggerNumber = leftNum;
            //    }

            //    long sumOfDigits = 0;
            //    while (biggerNumber != 0)
            //    {
            //        sumOfDigits += biggerNumber % 10;
            //        biggerNumber /= 10;
            //    }
            //    Console.WriteLine(Math.Abs(sumOfDigits));
            //}
        }
    }
}
