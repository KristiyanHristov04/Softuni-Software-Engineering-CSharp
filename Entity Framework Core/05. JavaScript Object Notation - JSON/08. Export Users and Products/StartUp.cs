using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext dbContext = new ProductShopContext();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            ImportData(dbContext);

            string result = GetUsersWithProducts(dbContext);
            Console.WriteLine(result);
        }

        public static void ImportData(ProductShopContext context)
        {
            string inputJsonUsers = File.ReadAllText(@"../../../Datasets/users.json");
            string inputJsonProducts = File.ReadAllText(@"../../../Datasets/products.json");
            string inputJsonCategories = File.ReadAllText(@"../../../Datasets/categories.json");
            string inputJsonCategoriesProducts = File.ReadAllText(@"../../../Datasets/categories-products.json");

            List<User>? users = JsonConvert
                .DeserializeObject<List<User>>(inputJsonUsers);
            context.Users.AddRange(users);
            context.SaveChanges();

            List<Product> products = JsonConvert
                .DeserializeObject<List<Product>>(inputJsonProducts);
            context.Products.AddRange(products);
            context.SaveChanges();

            List<Category> categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJsonCategories)
                .Where(c => c.Name != null)
                .ToList();
            context.Categories.AddRange(categories);
            context.SaveChanges();

            List<CategoryProduct> categoryProducts = JsonConvert
               .DeserializeObject<List<CategoryProduct>>(inputJsonCategoriesProducts);
            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                 .Users
                 .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(p => p.Buyer != null))
                 .OrderByDescending(u => u.ProductsSold
                                          .Where(p => p.Buyer != null)
                                          .Count())
                 .Select(u => new
                 {
                     firstName = u.FirstName,
                     lastName = u.LastName,
                     age = u.Age,
                     soldProducts = new
                     {
                         count = u.ProductsSold
                             .Where(p => p.Buyer != null)
                             .Count(),
                         products = u.ProductsSold
                             .Where(p => p.Buyer != null)
                             .Select(p => new
                             {
                                 name = p.Name,
                                 price = p.Price
                             })
                     }
                 })
                 .ToArray();

            var usersInfo = new
            {
                usersCount = users.Count(),
                users = users
            };

            string usersToJson = JsonConvert.SerializeObject(usersInfo, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            });

            return usersToJson;
        }
    }
}