using System;

namespace _01._String_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string startInput = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Done")
                {
                    break;
                }
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = commands[0];
                switch (mainCommand)
                {
                    case "Change":
                        string symbolToReplace = commands[1];
                        string newSymbol = commands[2];
                        startInput = startInput.Replace(symbolToReplace, newSymbol);
                        Console.WriteLine(startInput);
                        break;
                    case "Includes":
                        string substring = commands[1];
                        if (startInput.Contains(substring))
                        {
                            Console.WriteLine(true);
                        }
                        else
                        {
                            Console.WriteLine(false);
                        }
                        break;
                    case "End":
                        string lastSubstring = commands[1];
                        if (startInput.EndsWith(lastSubstring))
                        {
                            Console.WriteLine(true);
                        }
                        else
                        {
                            Console.WriteLine(false);
                        }
                        break;
                    case "Uppercase":
                        startInput = startInput.ToUpper();
                        Console.WriteLine(startInput);
                        break;
                    case "FindIndex":
                        string firstSymbolToFind = commands[1];
                        int index = startInput.IndexOf(firstSymbolToFind);
                        Console.WriteLine(index);
                        break;
                    case "Cut":
                        int startIndex = Convert.ToInt32(commands[1]);
                        int count = Convert.ToInt32(commands[2]);
                        string left = startInput.Substring(startIndex, count);
                        startInput = left;
                        Console.WriteLine(startInput);
                        break;
                }
            }
        }
    }
}
