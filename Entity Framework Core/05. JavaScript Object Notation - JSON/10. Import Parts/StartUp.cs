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
                string jsonPath = File.ReadAllText(@"../../../Datasets/parts.json");
                string result = ImportParts(dbContext, jsonPath);
                Console.WriteLine(result);
            }
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            Part[] parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => p.SupplierId <= 31)
                .ToArray();
            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count()}.";
        }
    }
}