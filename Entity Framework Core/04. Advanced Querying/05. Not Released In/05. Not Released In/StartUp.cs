using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;
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
                int year = Convert.ToInt32(Console.ReadLine());
                string result = GetBooksNotReleasedIn(db, year);
            }
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var b in books)
                sb.AppendLine(b);

            return sb.ToString().TrimEnd();
        }
    }
}