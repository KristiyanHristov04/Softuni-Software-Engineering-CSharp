using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using (ProductShopContext dbContext = new ProductShopContext())
            {
                //dbContext.Database.EnsureDeleted();
                //dbContext.Database.EnsureCreated();

                //string usersXml = File.ReadAllText(@"../../../Datasets/users.xml");
                //string productsXml = File.ReadAllText(@"../../../Datasets/products.xml");
                //string categoriesXml = File.ReadAllText(@"../../../Datasets/categories.xml");
                //string categoriesProductsXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");
                //ImportUsers(dbContext, usersXml);
                //ImportProducts(dbContext, productsXml);
                //ImportCategories(dbContext, categoriesXml);
                //ImportCategoryProducts(dbContext, categoriesProductsXml);

                string result = GetUsersWithProducts(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            UserInfoOutputModel[] userProducts = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderByDescending(u => u.ProductsSold.Count())
                .Select(u => new UserInfoOutputModel()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductInfoOutputModel()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(ps => new ProductInfoOutputModel()
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            UserProductOutputModel userProductsDto = new UserProductOutputModel()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = userProducts
            };

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserProductOutputModel), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, userProductsDto, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            CategoryOutputModel[] categories = context.Categories
                .Select(c => new CategoryOutputModel()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryOutputModel[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            xmlSerializer.Serialize(writer, categories, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            SoldProductOutputModel[] soldProducts = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new SoldProductOutputModel()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(ps => new ProductInfoOutputModel()
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    })
                    .ToArray()
                })
                .Take(5)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SoldProductOutputModel[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, soldProducts, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            ProductOutputModel[] products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductOutputModel()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductOutputModel[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            xmlSerializer.Serialize(writer, products, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("CategoryProducts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryProductsInputModel[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            CategoryProductsInputModel[] categoryProductDtos = (CategoryProductsInputModel[])xmlSerializer.Deserialize(reader);

            CategoryProduct[] categoryProducts = categoryProductDtos
                .Select(cp => new CategoryProduct()
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                })
                .ToArray();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryInputModel[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            CategoryInputModel[] categoryDtos = (CategoryInputModel[])xmlSerializer.Deserialize(reader);

            Category[] categories = categoryDtos
                .Select(c => new Category()
                {
                    Name = c.Name
                })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductInputModel[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            ProductInputModel[] productDtos = (ProductInputModel[])xmlSerializer.Deserialize(reader);

            Product[] products = productDtos
                .Select(p => new Product()
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserInputModel[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            UserInputModel[] userDtos = (UserInputModel[])xmlSerializer.Deserialize(reader);

            //User[] users = userDtos
            //    .Select(u => new User()
            //    {
            //        FirstName = u.FirstName,
            //        LastName = u.LastName,
            //        Age = u.Age
            //    })
            //    .ToArray();

            List<User> users = new List<User>();
            foreach (var userDto in userDtos)
            {
                User user = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
    }
}