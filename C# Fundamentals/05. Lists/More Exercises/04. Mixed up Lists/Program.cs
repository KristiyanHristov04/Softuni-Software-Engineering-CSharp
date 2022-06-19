using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list01 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list02 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();
            bool reachedEnd = false;
            int number01 = 0;
            int number02 = 0;

            if (list01.Count > list02.Count)
            {
                for (int i = 0; i < list01.Count; i++)
                {
                    if (reachedEnd)
                    {
                        number01 = list01[i];
                        number02 = list01[i + 1];
                        list01.RemoveAt(list01.Count - 1);
                        list01.RemoveAt(list01.Count - 1);
                        break;
                    }
                    for (int j = list02.Count - 1; j >= 0; j--)
                    {
                        if (j - 1 < 0)
                        {
                            reachedEnd = true;
                            result.Add(list01[i]);
                            result.Add(list02[j]);
                            list02.RemoveAt(list02.Count - 1);
                            break;
                        }
                        else
                        {
                            result.Add(list01[i]);
                            result.Add(list02[j]);
                            list02.RemoveAt(list02.Count - 1);
                            break;
                        }
                    }
                }
            }
            else if (list01.Count < list02.Count)
            {
                for (int i = 0; i < list01.Count; i++)
                {
                    if (reachedEnd)
                    {
                        number01 = list02[0];
                        number02 = list02[1];
                        list01.RemoveAt(list01.Count - 1);
                        list01.RemoveAt(list01.Count - 1);
                        break;
                    }
                    for (int j = list02.Count - 1; j >= 0; j--)
                    {
                        if (j - 2 == 1)
                        {
                            reachedEnd = true;
                            result.Add(list01[i]);
                            result.Add(list02[j]);
                            result.Add(list01[i + 1]);
                            result.Add(list02[j - 1]);
                            list02.RemoveAt(list02.Count - 1);
                            break;
                        }
                        else
                        {
                            result.Add(list01[i]);
                            result.Add(list02[j]);
                            list02.RemoveAt(list02.Count - 1);
                            break;
                        }
                    }
                }
            }

            if (number01 > number02)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i] <= number02 || result[i] >= number01)
                    {
                        result.Remove(result[i]);
                        i--;
                    }
                }
            }
            else if (number01 < number02)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i] <= number01 || result[i] >= number02)
                    {
                        result.Remove(result[i]);
                        i--;
                    }
                }
            }
            result.Sort();
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
