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
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                Console.WriteLine("Database created successfully");

                string xml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
                string result = ImportSuppliers(dbContext, xml);
                Console.WriteLine(result);
            }
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), root);

            using StringReader reader = new StringReader(inputXml);
            SupplierInputModel[] suppliersDto = (SupplierInputModel[])xmlSerializer.Deserialize(reader);

            Supplier[] suppliers = suppliersDto
                .Select(s => new Supplier()
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }
    }
}