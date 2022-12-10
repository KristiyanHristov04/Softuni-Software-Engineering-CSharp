using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;
        public Controller()
        {
            this.booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothId = this.booths.Models.Count + 1;
            Booth booth = new Booth(boothId, capacity);
            this.booths.AddModel(booth);
            return String.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            //Might need to change the order of the checking
            if (size != "Large" && size != "Middle" && size != "Small")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }

            ICocktail cocktail = null;
            switch (cocktailTypeName)
            {
                case "MulledWine":
                    cocktail = new MulledWine(cocktailName, size);
                    break;
                case "Hibernation":
                    cocktail = new Hibernation(cocktailName, size);
                    break;
                default:
                    return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            IBooth booth = this.booths.Models.First(x => x.BoothId == boothId);
            if (booth.CocktailMenu.Models.Any(cocktail => cocktail.Name == cocktailName && cocktail.Size == size))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            booth.CocktailMenu.AddModel(cocktail);
            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = null;
            switch (delicacyTypeName)
            {
                case "Gingerbread":
                    delicacy = new Gingerbread(delicacyName);
                    break;
                case "Stolen":
                    delicacy = new Stolen(delicacyName);
                    break;
                default:
                    return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = this.booths.Models.First(x => x.BoothId == boothId);
            if (booth.DelicacyMenu.Models.Any(delicacy => delicacy.Name == delicacyName))
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);
            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = this.booths.Models.First(x => x.BoothId == boothId);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(booth.ToString());
            return sb.ToString().TrimEnd();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = this.booths.Models.First(x => x.BoothId == boothId);
            double boothBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {boothBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");
            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var boothRep = this.booths.Models.Where(booth => !booth.IsReserved && booth.Capacity >= countOfPeople).OrderBy(booth => booth.Capacity).ThenByDescending(booth => booth.BoothId);
            if (boothRep.Count() == 0)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            IBooth chosenBooth = null;
            foreach (var booth in boothRep)
            {
                chosenBooth = booth;
                break;
            }

            chosenBooth.ChangeStatus();
            return String.Format(OutputMessages.BoothReservedSuccessfully, chosenBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderInformation = order.Split('/');
            string itemTypeName = orderInformation[0];
            string itemName = orderInformation[1];
            int countOfOrderedPieces = int.Parse(orderInformation[2]);
            string cocktailSizeIfItemIsCocktail = string.Empty;

            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                cocktailSizeIfItemIsCocktail = orderInformation[3];
            }

            if (itemTypeName != "MulledWine" && itemTypeName != "Hibernation" &&
                itemTypeName != "Gingerbread" && itemTypeName != "Stolen")
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            IBooth booth = this.booths.Models.First(x => x.BoothId == boothId);
            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                if (!booth.CocktailMenu.Models.Any(cocktail => cocktail.Name == itemName))
                {
                    return String.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                }
            }
            else if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                if (!booth.DelicacyMenu.Models.Any(delicacy => delicacy.Name == itemName))
                {
                    return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
            }

            ICocktail cocktail = null;
            if (cocktailSizeIfItemIsCocktail != "")
            {
                cocktail = booth.CocktailMenu.Models.First(x => x.Name == itemName);
                if (!booth.CocktailMenu.Models.Any(x => x.Name == itemName && x.GetType().Name == itemTypeName && x.Size == cocktailSizeIfItemIsCocktail))
                {
                    return String.Format(OutputMessages.CocktailStillNotAdded, cocktailSizeIfItemIsCocktail, itemName);
                }

                booth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces);
                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }

            IDelicacy delicacy = null;
            delicacy = booth.DelicacyMenu.Models.First(x => x.Name == itemName);
            if (!booth.DelicacyMenu.Models.Any(x => x.Name == itemName && x.GetType().Name == itemTypeName))
            {
                return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
            }

            booth.UpdateCurrentBill(delicacy.Price * countOfOrderedPieces);
            return String.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
        }
    }
}
