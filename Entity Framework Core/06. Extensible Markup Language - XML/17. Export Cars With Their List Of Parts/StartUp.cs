using CarDealer.Data;
using CarDealer.DTOs;
using CarDealer.Models;
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
                string result = GetCarsWithTheirListOfParts(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            CarOutputModel[] carDtos = context.Cars
                .Select(c => new CarOutputModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance,
                    Parts = c.PartsCars.Select(pc => new CarPartsOutputModel()
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(pc => pc.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
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