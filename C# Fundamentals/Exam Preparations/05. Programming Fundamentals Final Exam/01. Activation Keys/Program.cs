using System;

namespace _01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Generate")
                {
                    break;
                }
                string[] commands = input.Split(">>>");
                switch (commands[0])
                {
                    case "Contains":
                        string substring = commands[1];
                        if (rawKey.Contains(substring))
                        {
                            Console.WriteLine($"{rawKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string upperOrLower = commands[1];
                        int startIndex = Convert.ToInt32(commands[2]);
                        int endIndex = Convert.ToInt32(commands[3]) - 1;
                        string newText = string.Empty;
                        string oldText = string.Empty;
                        if (upperOrLower == "Upper")
                        {                           
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                oldText += rawKey[i];
                                newText += rawKey[i].ToString().ToUpper();                               
                            }
                            rawKey = rawKey.Replace(oldText, newText);
                        }
                        else if (upperOrLower == "Lower")
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                oldText += rawKey[i];
                                newText += rawKey[i].ToString().ToLower();
                            }
                            rawKey = rawKey.Replace(oldText, newText);
                        }
                        Console.WriteLine(rawKey);
                        break;
                    case "Slice":
                        int startIndex02 = Convert.ToInt32(commands[1]);
                        int endIndex02 = Convert.ToInt32(commands[2]) - 1;
                        string textToRemove = string.Empty;
                        for (int i = startIndex02; i <= endIndex02; i++)
                        {
                            textToRemove += rawKey[i];
                        }
                        rawKey = rawKey.Replace(textToRemove, "");
                        Console.WriteLine(rawKey);
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}
