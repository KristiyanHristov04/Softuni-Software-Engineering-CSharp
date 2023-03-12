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
                int result = RemoveBooks(db);
                Console.WriteLine(result);
            }
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToBeRemoved = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(booksToBeRemoved);

            context.SaveChanges();

            int countOfRemovedBooks = booksToBeRemoved.Count();

            return countOfRemovedBooks;
        }
    }
}