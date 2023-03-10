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
                string input = Console.ReadLine();
                string result = GetBooksByCategory(db, input);
                Console.WriteLine(result);
                //Console.WriteLine(result.Length);
            }
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            StringBuilder output = new StringBuilder();
            var allBooks = context.Books
                .Select(b => new
                {
                    b.Title,
                    Category = b.BookCategories.Select(bc => new
                    {
                        CategoryName = bc.Category.Name
                    }),
                })
                .OrderBy(b => b.Title)
                .ToArray();

            foreach (var book in allBooks)
            {
                foreach (var category in categories)
                {
                    if (book.Category.Any(c => c.CategoryName.ToLower() == category.ToLower()))
                    {
                        output.AppendLine(book.Title);
                    }
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}