namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
               .Prisoners
               .ToArray()
               .Where(p => ids.Contains(p.Id))
               .Select(p => new
               {
                   Id = p.Id,
                   Name = p.FullName,
                   CellNumber = p.Cell.CellNumber,
                   Officers = p.PrisonerOfficers
                       .Select(po => new
                       {
                           OfficerName = po.Officer.FullName,
                           Department = po.Officer.Department.Name
                       })
                       .OrderBy(o => o.OfficerName)
                       .ToArray(),
                   TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(po => po.Officer.Salary), 2)
               })
               .OrderBy(p => p.Name)
               .ThenBy(p => p.Id)
               .ToArray();

            string json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] prisonerNames = prisonersNames.Split(",").ToArray();

            ExportPrisonerDto[] prisoners = context.Prisoners
                .ToArray()
                .Where(p => prisonerNames.Contains(p.FullName))
                .Select(p => new ExportPrisonerDto()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Mails = p.Mails.Select(m => new ExportPrisonerMailDto()
                    {
                        Description = new string(m.Description.ToCharArray().Reverse().ToArray())
                    })
                    .ToArray()
                })
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Prisoners");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPrisonerDto[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder output = new StringBuilder();
            using StringWriter writer = new StringWriter(output);

            xmlSerializer.Serialize(writer, prisoners, namespaces);

            return output.ToString().TrimEnd();
        }
    }
}