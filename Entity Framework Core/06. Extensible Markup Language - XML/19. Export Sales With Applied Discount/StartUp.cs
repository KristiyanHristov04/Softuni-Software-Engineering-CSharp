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
                string result = GetSalesWithAppliedDiscount(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            SaleInputModel[] sales = context.Sales
                .Select(s => new SaleInputModel()
                {
                    Car = new SaleCarInputModel()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = (double)s.Car.PartsCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = (double)(s.Car.PartsCars.Sum(pc => pc.Part.Price) - (s.Car.PartsCars.Sum(pc => pc.Part.Price) * (s.Discount / 100)))
                })
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleInputModel[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, sales, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}