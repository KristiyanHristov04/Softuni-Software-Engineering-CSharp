using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commands = input.Split();
                int index = Convert.ToInt32(commands[1]);
                switch (commands[0])
                {
                    case "Shoot":
                        int power = Convert.ToInt32(commands[2]);
                        if (index >= 0 && index < targets.Count)
                        {
                            targets[index] -= power;
                            if (targets[index] <= 0)
                            {
                                targets.RemoveAt(index);
                            }
                        }
                        break;
                    case "Add":
                        int value = Convert.ToInt32(commands[2]);
                        if (index >= 0 && index < input.Length)
                        {
                            targets.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;
                    case "Strike":
                        int radius = Convert.ToInt32(commands[2]);
                        int leftToRemove = index - radius;
                        int rightToRemove = index + radius;
                        bool isValid = true;
                        if (rightToRemove >= targets.Count || leftToRemove > targets.Count)
                        {
                            isValid = false;
                            Console.WriteLine("Strike missed!");
                            break;
                        }
                        if (rightToRemove < 0 || leftToRemove < 0)
                        {
                            isValid = false;
                            Console.WriteLine("Strike missed!");
                            break;
                        }

                        //Ako ima strike shte removne celiq sequence zatova go preventvame 
                        if (leftToRemove == 0 && rightToRemove == targets.Count - 1)
                        {
                            input = Console.ReadLine();
                            continue;
                        }
                        if (isValid)
                        {
                            for (int i = leftToRemove; i <= rightToRemove; i++)
                            {
                                targets[i] = 0;
                            }
                        }

                        targets.RemoveAll(x => x == 0); //Remove all zeroes from the list
                        break;
                }
                input = Console.ReadLine();

            }
            Console.WriteLine(String.Join("|", targets));
        }
    }
}