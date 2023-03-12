using BookShop.Data;
using BookShop.Models;
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
                string result = CountCopiesByAuthor(db);
                Console.WriteLine(result);
            }
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();
            var authors = context.Authors
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}",
                    TotalBookCopies = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(a => a.TotalBookCopies)
                .ToArray();

               
            foreach (var author in authors)
            {
                output.AppendLine($"{author.FullName} - {author.TotalBookCopies}");
            }

            return output.ToString().TrimEnd();
        }
    }
}