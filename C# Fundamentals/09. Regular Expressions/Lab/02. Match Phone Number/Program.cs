using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"\+[3][5][9]([ -])[2]\1[0-9]{3}\1[0-9]{4}\b");
            var result = regex.Matches(input);
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
