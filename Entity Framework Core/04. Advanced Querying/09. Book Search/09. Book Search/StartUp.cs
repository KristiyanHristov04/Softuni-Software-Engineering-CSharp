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
                string result = GetBookTitlesContaining(db, input);
                Console.WriteLine(result);
            }
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder output = new StringBuilder();

            var allBooks = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            foreach (var book in allBooks)
            {
                output.AppendLine(book);
            }

            return output.ToString().TrimEnd();
        }
    }
}