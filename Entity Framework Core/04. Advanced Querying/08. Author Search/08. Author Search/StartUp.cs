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
                string result = GetAuthorNamesEndingIn(db, input);
                Console.WriteLine(result);
            }
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder output = new StringBuilder();

            var allAuthors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .ToArray()
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.FullName)
                .ToArray();

            foreach (var author in allAuthors)
            {
                output.AppendLine($"{author.FullName}");
            }

            return output.ToString().TrimEnd();
        }
    }
}