using CarDealer.Data;
using CarDealer.DTOs;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (CarDealerContext dbContext = new CarDealerContext())
            {
                string result = GetCarsWithDistance(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            CarOutputModel[] carDtos = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new CarOutputModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance
                })
                .Take(10)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, carDtos, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}