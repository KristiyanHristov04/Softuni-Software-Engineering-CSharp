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
                string result = GetCarsWithTheirListOfParts(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
               .Select(c => new
               {
                   car = new
                   {
                       c.Make,
                       c.Model,
                       c.TraveledDistance
                   },
                   parts = c.PartsCars.Select(p => new
                   {
                       p.Part.Name,
                       Price = $"{p.Part.Price:F2}"
                   })
               });

            string carsToJson = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return carsToJson;
        }
    }
}