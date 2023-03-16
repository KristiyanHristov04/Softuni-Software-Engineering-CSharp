using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using (CarDealerContext dbContext = new CarDealerContext())
            {
                string jsonPath = File.ReadAllText(@"../../../Datasets/customers.json");
                string result = ImportCustomers(dbContext, jsonPath);
                Console.WriteLine(result);
            }
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count()}.";
        }
    }
}