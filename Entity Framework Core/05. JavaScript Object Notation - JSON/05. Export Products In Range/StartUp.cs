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
                string result = GetProductsInRange(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToArray();

            string productsToJson = JsonConvert.SerializeObject(products, Formatting.Indented);
            return productsToJson;
        }
    }
}