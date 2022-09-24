using System;
using System.Linq;
namespace _01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            ListyIterator<string> list = new ListyIterator<string>(input.Split().Skip(1).ToArray());
            while (true)
            {
                input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (input == "Print")
                {
                    list.Print();
                }
                else if (input == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (input == "Move")
                {
                    Console.WriteLine(list.Move()); 
                }
            }
        }
    }
}
