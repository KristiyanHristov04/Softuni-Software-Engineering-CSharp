using System;

namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Reveal")
                {
                    break;
                }
                string[] commands = input.Split(":|:");
                string mainCommand = commands[0];
                switch (mainCommand)
                {
                    case "InsertSpace":
                        int index = int.Parse(commands[1]);
                        concealedMessage = concealedMessage.Insert(index, " ");
                        Console.WriteLine(concealedMessage);
                        break;
                    case "Reverse":
                        string substring = commands[1];
                        if (concealedMessage.Contains(substring))
                        {
                            int startIndex = concealedMessage.IndexOf(substring);
                            string text = concealedMessage.Substring(startIndex, substring.Length);
                            concealedMessage = concealedMessage.Remove(startIndex, substring.Length);
                            string reversedText = string.Empty;
                            for (int i = text.Length - 1; i >= 0; i--)
                            {
                                reversedText += text[i];
                            }
                            concealedMessage += reversedText;
                            Console.WriteLine(concealedMessage);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        string substring2 = commands[1];
                        string replacment = commands[2];
                        concealedMessage = concealedMessage.Replace(substring2, replacment);
                        Console.WriteLine(concealedMessage);
                        break;
                }
            }
            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }
    }
}
