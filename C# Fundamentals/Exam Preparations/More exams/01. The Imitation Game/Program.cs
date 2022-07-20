using System;

namespace _01._Programming_Fundamentals_Final_Exam_Retake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Decode")
                {
                    break;
                }
                string[] commands = input.Split('|');
                switch (commands[0])
                {
                    case "Move":
                        int numberOfLetters = int.Parse(commands[1]);
                        string firstLetters = encryptedMessage.Substring(0, numberOfLetters);
                        encryptedMessage = encryptedMessage.Remove(0, numberOfLetters);
                        encryptedMessage += firstLetters;
                        break;
                    case "Insert":
                        int index = int.Parse(commands[1]);
                        string value = commands[2];
                        encryptedMessage = encryptedMessage.Insert(index, value);
                        break;
                    case "ChangeAll":
                        string currText = commands[1];
                        string newText = commands[2];
                        encryptedMessage = encryptedMessage.Replace(currText, newText);
                        break;
                }
            }
            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
