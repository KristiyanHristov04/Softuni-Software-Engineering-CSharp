using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models.Enums;
using System;
using System.Text;

namespace BookShop 
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (BookShopContext db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                string input = Console.ReadLine();
                string result = GetBooksByAgeRestriction(db, input);
                Console.WriteLine(result);
            }
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder output = new StringBuilder();
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var booksWithRestriction = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            foreach (var book in booksWithRestriction)
            {
                output.AppendLine(book);
            }

            return output.ToString().TrimEnd();
        }
    }
}