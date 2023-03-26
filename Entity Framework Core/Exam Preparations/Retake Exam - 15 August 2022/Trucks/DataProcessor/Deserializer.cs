namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Despatchers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DespatcherInputModel[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            DespatcherInputModel[] despatcherDtos = (DespatcherInputModel[])xmlSerializer.Deserialize(reader);

            List<Despatcher> despatchers = new List<Despatcher>();
            StringBuilder output = new StringBuilder();
            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(despatcherDto.Position))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher despatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position
                };

                List<Truck> trucks = new List<Truck>();
                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType
                    };
                    trucks.Add(truck);
                }
                despatcher.Trucks = trucks;
                despatchers.Add(despatcher);
                output.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }
            context.Despatchers.AddRange(despatchers);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            List<ClientInputModel> clientDtos = JsonConvert.DeserializeObject<List<ClientInputModel>>(jsonString);
            StringBuilder output = new StringBuilder();

            List<Client> clients = new List<Client>();
            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (clientDto.Type == "usual")
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };

                foreach (var truckId in clientDto.Trucks.Distinct())
                {
                    Truck truck = context.Trucks.FirstOrDefault(t => t.Id == truckId);
                    if (truck == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    ClientTruck clientTruck = new ClientTruck()
                    {
                        Client = client,
                        Truck = truck
                    };

                    client.ClientsTrucks.Add(clientTruck);
                }
                clients.Add(client);
                output.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.AddRange(clients);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}