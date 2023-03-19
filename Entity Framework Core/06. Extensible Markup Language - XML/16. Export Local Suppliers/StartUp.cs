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
                string result = GetLocalSuppliers(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            SupplierOutputModel[] supplierDtos = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new SupplierOutputModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierOutputModel[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, supplierDtos, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}