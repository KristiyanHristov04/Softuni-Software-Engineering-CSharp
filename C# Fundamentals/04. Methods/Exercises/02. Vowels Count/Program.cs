using System;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(VowelsCount(text)); 
        }
        static int VowelsCount(string input)
        {
            int vowelsCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Convert.ToString(input[i]).ToLower() == "a" || Convert.ToString(input[i]).ToLower() == "e" || Convert.ToString(input[i]).ToLower() == "o" || Convert.ToString(input[i]).ToLower() == "i" 
                    || Convert.ToString(input[i]).ToLower() == "u")
                {
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }
    }
}
