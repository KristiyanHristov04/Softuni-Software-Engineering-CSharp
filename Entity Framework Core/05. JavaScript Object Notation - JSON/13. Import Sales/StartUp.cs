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
                string jsonPath = File.ReadAllText(@"../../../Datasets/sales.json");
                string result = ImportSales(dbContext, jsonPath);
                Console.WriteLine(result);
            }
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            Sale[] sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count()}.";
        }
    }
}