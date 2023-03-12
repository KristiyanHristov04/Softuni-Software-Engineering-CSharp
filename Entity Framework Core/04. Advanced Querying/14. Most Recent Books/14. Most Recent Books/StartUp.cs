using BookShop.Data;
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
                string result = GetMostRecentBooks(db);
                Console.WriteLine(result);
            }
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var categoriesWithBooks = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    CategoryBooks = c.CategoryBooks.Select(cb => new
                    {
                        cb.Book
                    })
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();

            foreach (var category in categoriesWithBooks)
            {
                output.AppendLine($"--{category.CategoryName}");
                int count = 1;
                foreach (var book in category.CategoryBooks.OrderByDescending(cb => cb.Book.ReleaseDate))
                {
                    if (count == 4)
                    {
                        break;
                    }
                    output.AppendLine($"{book.Book.Title} ({book.Book.ReleaseDate.Value.Year})");
                    count++;
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}