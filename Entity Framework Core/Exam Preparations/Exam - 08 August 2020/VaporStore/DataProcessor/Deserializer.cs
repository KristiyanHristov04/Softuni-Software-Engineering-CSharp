namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDto;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            ImportGameDeveloperGenreTagDto[] dtos = JsonConvert.DeserializeObject<ImportGameDeveloperGenreTagDto[]>(jsonString);
            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            StringBuilder output = new StringBuilder();
            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (dto.TagNames.Length == 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime releaseDate;
                bool isReleaseDateValid = DateTime.TryParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);
                if (!isReleaseDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = new Game()
                {
                    Name = dto.GameName,
                    Price = dto.Price,
                    ReleaseDate = releaseDate
                };

                Developer developer = developers.FirstOrDefault(d => d.Name == dto.DeveloperName);
                if (developer == null)
                {
                    Developer newDeveloper = new Developer()
                    {
                        Name = dto.DeveloperName
                    };

                    developers.Add(newDeveloper);
                    game.Developer = newDeveloper;
                }
                else
                {
                    game.Developer = developer;
                }

                Genre genre = genres.FirstOrDefault(d => d.Name == dto.GenreName);
                if (genre == null)
                {
                    Genre newGenre = new Genre()
                    {
                        Name = dto.GenreName
                    };

                    genres.Add(newGenre);
                    game.Genre = newGenre;
                }
                else
                {
                    game.Genre = genre;
                }

                foreach (var gameTag in dto.TagNames)
                {
                    Tag tagName = tags.FirstOrDefault(t => t.Name == gameTag);
                    if (tagName == null)
                    {
                        Tag newTag = new Tag()
                        {
                            Name = gameTag
                        };

                        tags.Add(newTag);
                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = newTag
                        });
                    }
                    else
                    {
                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = tagName
                        });
                    }
                }

                games.Add(game);
                output.AppendLine(String.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }

            context.Games.AddRange(games);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            ImportUserCardsDto[] userCardDtos = JsonConvert.DeserializeObject<ImportUserCardsDto[]>(jsonString);
            List<User> users = new List<User>();
            StringBuilder output = new StringBuilder();

            foreach (var userCardDto in userCardDtos)
            {
                if (!IsValid(userCardDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User()
                {
                    FullName = userCardDto.FullName,
                    Username = userCardDto.Username,
                    Email = userCardDto.Email,
                    Age = userCardDto.Age
                };

                List<Card> cards = new List<Card>();
                bool areAllCardsValid = true;
                foreach (var cardDto in userCardDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    CardType card;
                    bool isCardValid = Enum.TryParse(typeof(CardType), cardDto.Type, out object cardValue);
                    if (!isCardValid)
                    {
                        areAllCardsValid = false;
                        break;
                    }
                    card = (CardType)cardValue;

                    Card newCard = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = card
                    };

                    cards.Add(newCard);
                }

                if (areAllCardsValid)
                {
                    user.Cards = cards;
                    users.Add(user);
                    output.AppendLine(String.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Purchases");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), xmlRoot);
            using StringReader reader = new StringReader(xmlString);
            ImportPurchaseDto[] purchaseDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(reader);

            List<Purchase> purchases = new List<Purchase>();
            StringBuilder output = new StringBuilder();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime date;
                bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                if (!isDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                PurchaseType type;
                bool isTypeValid = Enum.TryParse(typeof(PurchaseType), purchaseDto.Type, out object typeValue);
                if (!isTypeValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                type = (PurchaseType)typeValue;

                Game game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);
                Card card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                Purchase purchase = new Purchase()
                {
                    Type = type,
                    ProductKey = purchaseDto.ProductKey,
                    Card = card,
                    Game = game,
                    Date = date
                };

                purchases.Add(purchase);
                output.AppendLine(String.Format(SuccessfullyImportedPurchase, purchase.Game.Name, purchase.Card.User.Username));
            }

            context.Purchases.AddRange(purchases);
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