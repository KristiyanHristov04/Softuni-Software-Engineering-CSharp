using System;
using System.Collections.Generic;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            List<string> validUsernames = new List<string>();

            for (int i = 0; i < usernames.Length; i++)
            {
                if (usernames[i].Length >= 3 && usernames[i].Length <= 16)
                {
                    string currentUsername = usernames[i];
                    bool isValid = false;
                    for (int j = 0; j < currentUsername.Length; j++)
                    {
                        if ((currentUsername[j] >= 'a' && currentUsername[j] <= 'z') ||
                            (currentUsername[j] >= 'A' && currentUsername[j] <= 'Z') ||
                            (currentUsername[j] >= '0' && currentUsername[j] <= '9') ||
                            (currentUsername[j] == '-') || (currentUsername[j] == '_'))
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        validUsernames.Add(currentUsername);
                    }
                }
            }
            foreach (var username in validUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
