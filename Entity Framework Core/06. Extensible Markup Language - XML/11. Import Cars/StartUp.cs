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
                string xml = File.ReadAllText(@"../../../Datasets/cars.xml");
                string result = ImportCars(dbContext, xml);
                Console.WriteLine(result);
            }
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
    }
}