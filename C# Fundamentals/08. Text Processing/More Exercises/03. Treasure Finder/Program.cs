using System;
using System.Collections.Generic;

namespace _03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] keys = Console.ReadLine().Split();
            Dictionary<string, string> treasureCoordinates = new Dictionary<string, string>();

            int currKeyIndex = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "find")
                {
                    break;
                }
                char[] symbols = input.ToCharArray();
                currKeyIndex = 0;
                for (int i = 0; i < symbols.Length; i++)
                {
                    if (currKeyIndex == keys.Length)
                    {
                        currKeyIndex = 0;
                    }
                    for (int j = currKeyIndex; j < keys.Length;)
                    {
                        int decrease = Convert.ToInt32(keys[j]);
                        symbols[i] -= Convert.ToChar(decrease);
                        currKeyIndex++;
                        break;
                    }  
                }
                string finalText = string.Empty;
                for (int i = 0; i < symbols.Length; i++)
                {
                    finalText += symbols[i];
                }
                int treasureTypeStartIndex = finalText.IndexOf("&");
                int treasureTypeEndIndex = finalText.LastIndexOf("&");
                int treasureCoordinatesStartIndex = finalText.IndexOf("<");
                int treasureCoordinatesEndIndex = finalText.IndexOf(">");
                string treasureType = string.Empty;
                string treasureCoords = string.Empty;
                for (int i = treasureTypeStartIndex + 1; i < treasureTypeEndIndex; i++)
                {
                    treasureType += finalText[i];
                }

                for (int i = treasureCoordinatesStartIndex + 1; i < treasureCoordinatesEndIndex; i++)
                {
                    treasureCoords += finalText[i];
                }

                treasureCoordinates.Add(treasureType, treasureCoords);
            }
            foreach (var treasure in treasureCoordinates)
            {
                Console.WriteLine($"Found {treasure.Key} at {treasure.Value}");
            }
        }
    }
}
