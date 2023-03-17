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
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                string xml = File.ReadAllText(@"../../../Datasets/users.xml");
                string result = ImportUsers(dbContext, xml);
                Console.WriteLine(result);
            }
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