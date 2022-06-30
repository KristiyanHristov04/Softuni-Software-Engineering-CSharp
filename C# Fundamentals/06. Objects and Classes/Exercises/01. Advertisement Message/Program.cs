using System;
using System.Collections.Generic;

namespace _01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = Convert.ToInt32(Console.ReadLine());
            string[] phrases = {"Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."};
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas.", "Sofia.", "Plovdiv.", "Varna.", "Ruse." };
           
            Random random = new Random();
            List<string> messages = new List<string>();

            for (int i = 0; i < numberOfMessages; i++)
            {
                string sentence = String.Empty;

                int phraseIndex = random.Next(0, phrases.Length);
                string phrase = phrases[phraseIndex];

                int eventIndex = random.Next(0, events.Length);
                string @event = events[phraseIndex];

                int authorIndex = random.Next(0, authors.Length);
                string author = authors[authorIndex];

                int cityIndex = random.Next(0, cities.Length);
                string city = cities[cityIndex];

                sentence = $"{phrase} {@event} {@author} - {city}";
                messages.Add(sentence);
            }

            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
