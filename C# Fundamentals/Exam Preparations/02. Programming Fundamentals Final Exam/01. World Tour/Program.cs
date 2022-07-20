using System;

namespace _01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Travel")
                {
                    break;
                }
                string[] commands = input.Split(':');
                string mainCommand = commands[0];
                switch (mainCommand)
                {
                    case "Add Stop":
                        int index = int.Parse(commands[1]);
                        string value = commands[2];
                        if (index >= 0 && index <= stops.Length - 1)
                        {
                            stops = stops.Insert(index, value);
                        }
                        Console.WriteLine(stops);
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        if (startIndex >= 0 && startIndex <= stops.Length - 1 && endIndex >= 0 && endIndex <= stops.Length - 1)
                        {
                            int count = endIndex - startIndex + 1;
                            stops = stops.Remove(startIndex, count);
                        }
                        Console.WriteLine(stops);
                        break;
                    case "Switch":
                        string oldString = commands[1];
                        string newString = commands[2];
                        stops = stops.Replace(oldString, newString);
                        Console.WriteLine(stops);
                        break;
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
