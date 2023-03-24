namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CoachInputModel[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            CoachInputModel[] coachDtos = (CoachInputModel[])xmlSerializer.Deserialize(reader);

            StringBuilder output = new StringBuilder();
            List<Coach> coaches = new List<Coach>();
            foreach (var coachDto in coachDtos)
            {
                if (!IsValid(coachDto) || string.IsNullOrEmpty(coachDto.Nationality))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality
                };

                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime footballerContractStartDate;
                    bool isFootballerContractStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out footballerContractStartDate);

                    if (!isFootballerContractStartDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime footballerContractEndDate;
                    bool isFootballerContractEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out footballerContractEndDate);

                    if (!isFootballerContractEndDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (footballerContractStartDate >= footballerContractEndDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = footballerContractStartDate,
                        ContractEndDate = footballerContractEndDate,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        PositionType = (PositionType)footballerDto.PositionType,
                    };

                    coach.Footballers.Add(footballer);
                }
                coaches.Add(coach);
                output.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }
            context.Coaches.AddRange(coaches);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            List<TeamInputModel> teamDtos = JsonConvert.DeserializeObject<List<TeamInputModel>>(jsonString);
            StringBuilder output = new StringBuilder();
            List<Team> teams = new List<Team>();

            foreach (var teamDto in teamDtos)
            {
                if (!IsValid(teamDto) || teamDto.Trophies == 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies
                };

                foreach (var footballerId in teamDto.FootballersIds.Distinct())
                {
                    Footballer footballer = context.Footballers.FirstOrDefault(f => f.Id == footballerId);
                    if (footballer == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer()
                    {
                        //FootballerId = footballerId
                        Footballer = footballer
                    });
                }
                teams.Add(team);
                output.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }
            context.Teams.AddRange(teams);
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
