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
                string date = Console.ReadLine();
                string result = GetBooksReleasedBefore(db, date);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder output = new StringBuilder();
            string[] yearSplitted = date.Split('-', StringSplitOptions.RemoveEmptyEntries);
            int day = Convert.ToInt32(yearSplitted[0]);
            int month = Convert.ToInt32(yearSplitted[1]);
            int year = Convert.ToInt32(yearSplitted[2]);
            DateTime givenDateTime = new DateTime(year, month, day);

            var allBooks = context.Books
                .Where(b => b.ReleaseDate < givenDateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var book in allBooks)
            {
                output.AppendLine($"{book.Title} - {book.EditionType.ToString()} - ${book.Price:f2}");
            }

            return output.ToString().TrimEnd();
        }
    }
}