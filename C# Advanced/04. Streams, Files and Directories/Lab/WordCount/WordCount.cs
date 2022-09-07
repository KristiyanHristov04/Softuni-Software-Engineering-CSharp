namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Queue<string> wordsToLook = new Queue<string>();
            Dictionary<string, int> words = new Dictionary<string, int>();
            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                string sentence = wordsReader.ReadToEnd().ToLower();
                string[] allWords = sentence.Split(' ');
                for (int i = 0; i < allWords.Length; i++)
                {
                    words.Add(allWords[i], 0);
                    wordsToLook.Enqueue(allWords[i]);
                }
            }

            string text = string.Empty;
            using (StreamReader textReader = new StreamReader(textFilePath))
            {
                text = textReader.ReadToEnd().ToLower();
            }

            while (wordsToLook.Count > 0)
            {
                string currentWord = wordsToLook.Dequeue();
                string[] textSplitted = text.Split(new char[] {' ', '.', ',', '!', '?', '-'}, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < textSplitted.Length; i++)
                {
                    if (textSplitted[i] == currentWord)
                    {
                        words[currentWord]++;
                    }
                }
            }

            foreach (var word in words.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
