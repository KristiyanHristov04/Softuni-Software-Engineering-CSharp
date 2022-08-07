using System;
using System.Collections.Generic;
namespace _03._Followers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, UserInformation> users = new Dictionary<string, UserInformation>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Log out")
                {
                    break;
                }
                string[] commands = input.Split(": ",StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = commands[0];
                string currUsername = commands[1];
                switch (mainCommand)
                {
                    case "New follower":
                        if (users.ContainsKey(currUsername))
                        {
                            continue;
                        }
                        else
                        {
                            UserInformation userInformation = new UserInformation(0, 0);
                            users.Add(currUsername, userInformation);
                        }
                        break;
                    case "Like":
                        int countOfLikes = Convert.ToInt32(commands[2]);
                        if (users.ContainsKey(currUsername))
                        {
                            users[currUsername].Likes += countOfLikes;
                        }
                        else
                        {
                            UserInformation userInformation = new UserInformation(0, countOfLikes);
                            users.Add(currUsername, userInformation);
                        }
                        break;
                    case "Comment":
                        if (users.ContainsKey(currUsername))
                        {
                            users[currUsername].Comments += 1;
                        }
                        else
                        {
                            UserInformation userInformation = new UserInformation(1, 0);
                            users.Add(currUsername, userInformation);
                        }
                        break;
                    case "Blocked":
                        if (users.ContainsKey(currUsername))
                        {
                            users.Remove(currUsername);
                        }
                        else
                        {
                            Console.WriteLine($"{currUsername} doesn't exist.");
                        }
                        break;
                }
            }
            Console.WriteLine(users.Count + " followers");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}: {user.Value.Likes + user.Value.Comments}");
            }
        }
    }
    class UserInformation
    {
        public int Comments { get; set; } 
        public int Likes { get; set; }
        public UserInformation(int comments, int likes)
        {
            this.Comments = comments;
            this.Likes = likes;
        }
    }
}
