using CarDealer.Data;
using CarDealer.DTOs;
using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using (CarDealerContext dbContext = new CarDealerContext())
            {
                string xml = File.ReadAllText(@"../../../Datasets/parts.xml");
                string result = ImportParts(dbContext, xml);
                Console.WriteLine(result);
            }
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), root);

            using StringReader reader = new StringReader(inputXml);
            PartInputModel[] partsDto = (PartInputModel[])xmlSerializer.Deserialize(reader);

            Part[] parts = partsDto
                .Where(p => p.SupplierId >= 1 && p.SupplierId <= 31)
                .Select(p => new Part()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }
    }
}