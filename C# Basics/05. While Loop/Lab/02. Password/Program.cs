using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            //02. Password
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string logInPassword = Console.ReadLine();

            while (logInPassword != password)
            {
                logInPassword = Console.ReadLine();
            }
            Console.WriteLine("Welcome " + username + "!");
        }
    }
}
