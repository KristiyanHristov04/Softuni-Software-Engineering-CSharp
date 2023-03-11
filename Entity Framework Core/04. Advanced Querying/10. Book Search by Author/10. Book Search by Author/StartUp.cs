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
                string result = GetBooksByAuthor(db, input);
                Console.WriteLine(result);
            }
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder output = new StringBuilder();

            var booksAndAuthors = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFullName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToArray();

            foreach (var book in booksAndAuthors)
            {
                output.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return output.ToString().TrimEnd();
        }
    }
}