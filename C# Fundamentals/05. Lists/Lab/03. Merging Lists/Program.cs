using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list01 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list02 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> mergedList = new List<int>();
            int list01Count = list01.Count;
            int list02Count = list02.Count;

            if (list01.Count > list02.Count)
            {
                for (int i = 0; i < list01.Count; i++)
                {
                    mergedList.Add(list01[i]);
                    if (list02Count > 0)
                    {
                        mergedList.Add(list02[i]);
                        list02Count--;
                    }
                    
                }
            }
            else if(list02.Count > list01.Count)
            {
                for (int i = 0; i < list02.Count; i++)
                {
                    
                    if (list01Count > 0)
                    {
                        mergedList.Add(list01[i]);
                        list01Count--;
                    }
                    mergedList.Add(list02[i]);
                }
            }
            else if(list02.Count == list01.Count)
            {
                for (int i = 0; i < list01.Count; i++)
                {
                    mergedList.Add(list01[i]);
                    mergedList.Add(list02[i]);
                }
            }
            Console.WriteLine(String.Join(" ", mergedList));
        }
    }
}
