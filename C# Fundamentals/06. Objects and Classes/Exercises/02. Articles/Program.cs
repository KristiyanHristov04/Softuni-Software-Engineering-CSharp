using System;

namespace _02._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] title = Console.ReadLine().Split(", ");
            int numberOfCommands = Convert.ToInt32(Console.ReadLine());

            Article article = new Article(title[0], title[1], title[2]);

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] currentCommands = Console.ReadLine().Split(": ");

                switch (currentCommands[0])
                {
                    case "Edit":
                        article.Content = article.Edit(currentCommands[1]);
                        break;
                    case "ChangeAuthor":
                        article.Author = article.ChangeAuthor(currentCommands[1]);
                        break;
                    case "Rename":
                        article.Title = article.Rename(currentCommands[1]);
                        break;
                }
            }
            Console.WriteLine(article);
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

        public string Edit(string command)
        {
            return command;
        }

        public string ChangeAuthor(string command)
        {
            return command;
        }

        public string Rename(string command)
        {
            return command;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
