using System;
namespace CustomStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();
            stack.Push(5);
            stack.Push(29);
            stack.Push(15);
            Console.WriteLine(stack);
            stack.Pop();
            Console.WriteLine(stack);
            stack.Peek();
            stack.Contains(51);
        }
    }
}
