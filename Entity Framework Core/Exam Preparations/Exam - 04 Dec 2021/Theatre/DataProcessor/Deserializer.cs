namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            StringBuilder output = new StringBuilder();
            using StringReader reader = new StringReader(xmlString);

            ImportPlayDto[] playDtos = (ImportPlayDto[])xmlSerializer.Deserialize(reader);
            List<Play> plays = new List<Play>();

            foreach (var playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre;
                bool isGenreValid = Enum.TryParse(typeof(Genre), playDto.Genre,
                    out object genreValue);
                if (!isGenreValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                genre = (Genre)genreValue;

                TimeSpan duration;
                bool isTimeSpanValid = TimeSpan.TryParseExact(playDto.Duration,
                    "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, 
                    out duration);
                if (!isTimeSpanValid || duration.Hours < 1)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                plays.Add(play);
                output.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            StringBuilder output = new StringBuilder();
            using StringReader reader = new StringReader(xmlString);

            ImportCastDto[] castDtos = (ImportCastDto[])xmlSerializer.Deserialize(reader);
            List<Cast> casts = new List<Cast>();

            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                casts.Add(cast);
                output.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            ImportTheatreTicketsDto[] theatreTicketDtos = JsonConvert.DeserializeObject<ImportTheatreTicketsDto[]>(jsonString);
            StringBuilder output = new StringBuilder();
            List<Theatre> theatres = new List<Theatre>();

            foreach (var theatreTicketDto in theatreTicketDtos)
            {
                if (!IsValid(theatreTicketDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Name = theatreTicketDto.Name,
                    NumberOfHalls = theatreTicketDto.NumberOfHalls,
                    Director = theatreTicketDto.Director
                };

                List<Ticket> tickets = new List<Ticket>();
                foreach (var ticketDto in theatreTicketDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    tickets.Add(ticket);
                }
                theatre.Tickets = tickets;
                theatres.Add(theatre);
                output.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
