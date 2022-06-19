using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> finalList = new List<int>();
            int middleNumber = numbers[numbers.Count / 2];
            bool flag = false;
            if (numbers.Count % 2 == 0)
            {
                for (int i = 0; i < numbers.Count; i++)
                {                    
                    finalList.Add(numbers[i] + numbers.Last());
                    numbers.RemoveAt(numbers.Count - 1);
                }
            }
            else
            {
                flag = true;            
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] == middleNumber)
                    {
                        break;
                    }
                    else
                    {
                        finalList.Add(numbers[i] + numbers.Last());
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                    
                }
            }
            if (!flag)
            {
                Console.WriteLine(String.Join(" ", finalList));
            }
            else if(flag)
            {
                Console.WriteLine(String.Join(" ", finalList) + " " + middleNumber);
            }
            
        }
    }
}
