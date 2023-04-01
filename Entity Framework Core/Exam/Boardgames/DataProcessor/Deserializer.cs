namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Creators");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCreatorDto[]), xmlRoot);
            StringBuilder output = new StringBuilder();
            using StringReader reader = new StringReader(xmlString);
            ImportCreatorDto[] creatorDtos = (ImportCreatorDto[])xmlSerializer.Deserialize(reader);
            List<Creator> creators = new List<Creator>();

            foreach (var creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName
                };

                List<Boardgame> boardgames = new List<Boardgame>();
                foreach (var boardgameDto in creatorDto.Boardgames)
                {
                    if (string.IsNullOrEmpty(boardgameDto.Name))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!IsValid(boardgameDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics
                    };

                    boardgames.Add(boardgame);
                }
                creator.Boardgames = boardgames;
                creators.Add(creator);
                output.AppendLine(String.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }

            context.Creators.AddRange(creators);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ImportSellerDto[] sellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);
            List<Seller> sellers = new List<Seller>();

            foreach (var sellerDto in sellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website
                };

                List<BoardgameSeller> boardgamesSellers = new List<BoardgameSeller>();
                foreach (var boardgameId in sellerDto.Boardgames.Distinct())
                {
                    Boardgame boardgame = context.Boardgames.FirstOrDefault(b => b.Id == boardgameId);
                    if (boardgame == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        Boardgame = boardgame,
                        Seller = seller
                    };

                    boardgamesSellers.Add(boardgameSeller);
                }
                seller.BoardgamesSellers = boardgamesSellers;
                sellers.Add(seller);
                output.AppendLine(String.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(sellers);
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
