using System;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string correctPassword = null;
            int numberOfAttempts = 0;
            for (int i = username.Length - 1; i >= 0; i--)
            {
                correctPassword += username[i];
            }
           
            for (int i = 1; i <= 4; i++)
            {

                string password = Console.ReadLine();
                if (password != correctPassword)
                {                   
                    numberOfAttempts++;
                    if (numberOfAttempts == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        return;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else if(password == correctPassword)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
            }

        }
    }
}
