using System;
using System.Collections.Generic;
using System.Linq;
namespace _08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];
                if (command == "3:1") break;

                int startIndex = int.Parse(commands[1]);
                int endIndex = int.Parse(commands[2]);
                string concatedWord = "";
                if (endIndex > myList.Count - 1 || endIndex < 0)
                {
                    endIndex = myList.Count - 1;
                }

                if (startIndex < 0 || startIndex > myList.Count - 1)
                {
                    startIndex = 0;
                }

                if (command == "merge")
                {
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatedWord += myList[i];
                    }
                    myList.RemoveRange(startIndex, endIndex - startIndex + 1);
                    myList.Insert(startIndex, concatedWord);
                }
                else if (command == "divide")
                {
                    var dividedList = new List<string>();
                    int partitions = int.Parse(commands[2]);
                    string word = myList[startIndex];
                    myList.RemoveAt(startIndex);
                    int parts = word.Length / partitions;
                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            dividedList.Add(word.Substring(i * parts));
                        }
                        else
                        {
                            dividedList.Add(word.Substring(i * parts, parts));
                        }
                    }
                    myList.InsertRange(startIndex, dividedList);
                }
            }

            Console.WriteLine(string.Join(" ", myList));
        }
    }
}
