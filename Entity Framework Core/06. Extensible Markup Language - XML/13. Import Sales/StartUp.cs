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

                string suppliersXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
                string partsXml = File.ReadAllText(@"../../../Datasets/parts.xml");
                string carsXml = File.ReadAllText(@"../../../Datasets/cars.xml");
                string customersXml = File.ReadAllText(@"../../../Datasets/customers.xml");
                ImportSuppliers(dbContext, suppliersXml);
                ImportParts(dbContext, partsXml);
                ImportCars(dbContext, carsXml);
                ImportCustomers(dbContext, customersXml);

                string xml = File.ReadAllText(@"../../../Datasets/sales.xml");
                string result = ImportSales(dbContext, xml);
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
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CarInputModel>), root);

            List<CarInputModel> carsDto = new List<CarInputModel>();
            using (StringReader reader = new StringReader(inputXml))
            {
                carsDto = (List<CarInputModel>)xmlSerializer.Deserialize(reader);
            }

            List<Car> cars = new List<Car>();
            foreach (var carDto in carsDto)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var partId in carDto.PartsId.Select(p => p.Id).Distinct())
                {
                    if (!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }

                    car.PartsCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerInputModel[]), root);

            using StringReader reader = new StringReader(inputXml);
            CustomerInputModel[] customersDto = (CustomerInputModel[])xmlSerializer.Deserialize(reader);

            Customer[] customers = customersDto
                .Select(c => new Customer()
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleInputModel[]), root);

            using StringReader reader = new StringReader(inputXml);
            SaleInputModel[] salesDto = (SaleInputModel[])xmlSerializer.Deserialize(reader);

            int[] carValidIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            Sale[] sales = salesDto
                .Where(s => carValidIds.Contains(s.CarId))
                .Select(s => new Sale()
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                })
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }
    }
}