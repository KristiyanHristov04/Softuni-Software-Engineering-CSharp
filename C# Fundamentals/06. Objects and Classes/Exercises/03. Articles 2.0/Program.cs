using System;
using System.Collections.Generic;

namespace _02._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = Convert.ToInt32(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] currentCommands = Console.ReadLine().Split(", ");
                Article currentArticle = new Article(currentCommands[0], currentCommands[1], currentCommands[2]);
                articles.Add(currentArticle);
            }

            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
