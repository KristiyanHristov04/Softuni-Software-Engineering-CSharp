using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (ProductShopContext dbContext = new ProductShopContext())
            {
                string result = GetSoldProducts(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(sp => sp.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLastName = ps.Buyer.LastName,
                    })
                })
                .ToArray();

            string usersToJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            return usersToJson;
        }
    }
}