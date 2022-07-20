using System;

namespace _01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string startPassword = Console.ReadLine();
            string newPassword = string.Empty;
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
                    case "TakeOdd":
                        for (int i = 1; i < startPassword.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                newPassword += startPassword[i];
                            }
                        }
                        startPassword = newPassword;
                        Console.WriteLine(startPassword);
                        break;
                    case "Cut":
                        int index = Convert.ToInt32(commands[1]);
                        int length = Convert.ToInt32(commands[2]);
                        startPassword = startPassword.Remove(index, length);
                        Console.WriteLine(startPassword);
                        break;
                    case "Substitute":
                        string substring = commands[1];
                        string substitute = commands[2];
                        if (startPassword.Contains(substring))
                        {
                            startPassword = startPassword.Replace(substring, substitute);
                            Console.WriteLine(startPassword);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
            }
            Console.WriteLine($"Your password is: {startPassword}");

        }
    }
}
