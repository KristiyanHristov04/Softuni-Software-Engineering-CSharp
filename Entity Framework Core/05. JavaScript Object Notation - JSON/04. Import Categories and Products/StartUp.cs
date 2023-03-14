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
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                string inputJsonUsers = File.ReadAllText(@"../../../Datasets/users.json");
                ImportUsers(dbContext, inputJsonUsers);

                string inputJsonProducts = File.ReadAllText(@"../../../Datasets/products.json");
                ImportProducts(dbContext, inputJsonProducts);

                string inputJsonCategories = File.ReadAllText(@"../../../Datasets/categories.json");
                ImportCategories(dbContext, inputJsonProducts);

                string inputJsonCategoryProducts = File.ReadAllText(@"../../../Datasets/categories-products.json");
                string result = ImportCategoryProducts(dbContext, inputJsonCategoryProducts);
                Console.WriteLine(result);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            List<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count}";
        }
    }
}