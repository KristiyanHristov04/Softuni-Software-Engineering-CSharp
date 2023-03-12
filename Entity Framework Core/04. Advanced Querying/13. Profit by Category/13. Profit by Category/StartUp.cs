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
                string result = GetTotalProfitByCategory(db);
                Console.WriteLine(result);
            }
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToArray();


            foreach (var category in categories)
            {
                output.AppendLine($"{category.CategoryName} ${category.TotalProfit:f2}");
            }
            return output.ToString().TrimEnd();
        }
    }
}