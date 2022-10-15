using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();
            Console.WriteLine(stackOfStrings.IsEmpty());
            stackOfStrings.AddRange(new List<string> { "3", "2", "1" });
            Console.WriteLine(stackOfStrings.IsEmpty());
        }
    }
}
