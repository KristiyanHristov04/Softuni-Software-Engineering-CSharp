using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Chat_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] commands = input.Split(' ');
                string message = commands[1];
                switch (commands[0])
                {
                    case "Chat":
                        chat.Add(message);
                        break;
                    case "Delete":
                        if (chat.Contains(message))
                        {
                            chat.Remove(message);
                        }
                        break;
                    case "Edit":
                        if (chat.Contains(message))
                        {
                            string editedVersion = commands[2];
                            for (int i = 0; i < chat.Count; i++)
                            {
                                if (chat[i] == message)
                                {
                                    chat[i] = editedVersion;
                                    break;
                                }
                            }
                        }
                        break;
                    case "Pin":
                        if (chat.Contains(message))
                        {
                            chat.Remove(message);
                            chat.Add(message);
                        }
                        break;
                    case "Spam":
                        for (int i = 1; i < commands.Length; i++)
                        {
                            chat.Add(commands[i]);
                        }
                        break;
                }
            }
            foreach (var message in chat)
            {
                Console.WriteLine(message);
            }
        }
    }
}
