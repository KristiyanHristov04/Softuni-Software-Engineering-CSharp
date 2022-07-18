using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            string input = Console.ReadLine();
            Regex regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][A-z]+\b");
            var result = regex.Matches(input);

            foreach (Match item in result)
            {
                Console.Write(item + " ");
            }
        }
    }
}
