using System;
using System.Collections.Generic;

namespace _05._HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string titleContent = Console.ReadLine();
            List<string> allComments = new List<string>();
            while (true)
            {
                string comments = Console.ReadLine();
                if(comments == "end of comments")
                {
                    break;
                }
                allComments.Add(comments);
            }
            Console.WriteLine("<h1>");
            Console.WriteLine($" {title}");
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine($" {titleContent}");
            Console.WriteLine("</article>");
            foreach (var comment in allComments)
            {
                Console.WriteLine("<div>");
                Console.WriteLine($" {comment}");
                Console.WriteLine("</div>");
            }

        }
    }
}
