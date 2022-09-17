using System;
namespace CustomQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue();
            queue.Enqueue(1);
            queue.Enqueue(10);
            queue.Enqueue(100);
            queue.Dequeue();
            queue.Peek();
            queue.ForEach(x => Console.WriteLine(x));
            queue.Clear();
        }
    }
}
