using BookShop.Data;
using BookShop.Models.Enums;
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
                string result = GetGoldenBooks(db);
                Console.WriteLine(result);
                //Console.WriteLine("Check length: " + result.Length);
            }
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var type = Enum.Parse<EditionType>("Gold");
            StringBuilder output = new StringBuilder();

            var allGoldenBooks = context.Books
                .Where(b => b.EditionType == type && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in allGoldenBooks)
            {
                output.AppendLine(book);
            }

            return output.ToString().TrimEnd();
        }
    }
}