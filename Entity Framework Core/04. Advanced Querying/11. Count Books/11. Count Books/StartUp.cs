using BookShop.Data;

namespace BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (BookShopContext db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                int bookTitleLength = Convert.ToInt32(Console.ReadLine());
                int result = CountBooks(db, bookTitleLength);
                Console.WriteLine(result);
            }
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int count = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return count;
        }
    }
}