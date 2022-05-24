using System;

namespace PasswordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            string enterPassword = Console.ReadLine();
            if (enterPassword == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}

