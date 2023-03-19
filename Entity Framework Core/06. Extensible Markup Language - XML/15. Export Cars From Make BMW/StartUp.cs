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
                string result = GetCarsFromMakeBmw(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            CarOutputModel[] carDtos = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new CarOutputModel()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance
                })
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