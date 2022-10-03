using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            int pearLength = 4;
            int flourLength = 5;
            int porkLength = 4;
            int oliveLength = 5;
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            int numberOfFoundWords = 0;
            List<string> foundWords = new List<string>();
            while (consonants.Count > 0)
            {
                char currentVowel = vowels.Dequeue();
                vowels.Enqueue(currentVowel);
                char currentConsonant = consonants.Pop();
                if (pear.Contains(currentConsonant))
                {
                    pear = pear.Replace(currentConsonant, ' ');
                    pearLength--;
                }
                if (flour.Contains(currentConsonant))
                {
                    flour = flour.Replace(currentConsonant, ' ');
                    flourLength--;
                }
                if (pork.Contains(currentConsonant))
                {
                    pork = pork.Replace(currentConsonant, ' ');
                    porkLength--;
                }
                if (olive.Contains(currentConsonant))
                {
                    olive = olive.Replace(currentConsonant, ' ');
                    oliveLength--;
                }

                if (pear.Contains(currentVowel))
                {
                    pear = pear.Replace(currentVowel, ' ');
                    pearLength--;
                }
                if (flour.Contains(currentVowel))
                {
                    flour = flour.Replace(currentVowel, ' ');
                    flourLength--;
                }
                if (pork.Contains(currentVowel))
                {
                    pork = pork.Replace(currentVowel, ' ');
                    porkLength--;
                }
                if (olive.Contains(currentVowel))
                {
                    olive = olive.Replace(currentVowel, ' ');
                    oliveLength--;
                }
            }
            if (pearLength == 0)
            {
                numberOfFoundWords++;
                foundWords.Add("pear");
            }
            if (flourLength == 0)
            {
                numberOfFoundWords++;
                foundWords.Add("flour");
            }
            if (porkLength == 0)
            {
                numberOfFoundWords++;
                foundWords.Add("pork");
            }
            if (oliveLength == 0)
            {
                numberOfFoundWords++;
                foundWords.Add("olive");
            }
            Console.WriteLine($"Words found: {numberOfFoundWords}");
            foreach (var word in foundWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
