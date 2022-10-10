using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int valueOfTheTaskToBeKilled = Convert.ToInt32(Console.ReadLine());
            int threadWhoKillsTheTask = 0;
            bool isTaskKilled = false;

            while (!isTaskKilled)
            {
                int currentThread = threads.Peek();
                int currentTask = tasks.Peek();
                if (valueOfTheTaskToBeKilled == currentTask)
                {
                    threadWhoKillsTheTask = currentThread;
                    break;
                }

                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (currentThread < currentTask)
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {threadWhoKillsTheTask} killed task {valueOfTheTaskToBeKilled}");
            Console.WriteLine(String.Join(" ", threads));
        }
    }
}
