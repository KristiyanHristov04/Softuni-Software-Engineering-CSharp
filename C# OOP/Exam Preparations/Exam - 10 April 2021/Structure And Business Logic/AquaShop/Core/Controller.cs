using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case "SaltwaterAquarium":
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            this.aquariums.Add(aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            switch (decorationType)
            {
                case "Ornament":
                    decoration = new Ornament();
                    break;
                case "Plant":
                    decoration = new Plant();
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            this.decorations.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(aquarium => aquarium.Name == aquariumName);
            IFish fish = null;
            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (aquarium.GetType().Name == "FreshwaterAquarium" && fish.GetType().Name == "SaltwaterFish")
            {
                return OutputMessages.UnsuitableWater;
            }
            else if (aquarium.GetType().Name == "SaltwaterAquarium" && fish.GetType().Name == "FreshwaterFish")
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);
            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(aquarium => aquarium.Name == aquariumName);
            decimal price = 0;
            price += aquarium.Fish.Select(fish => fish.Price).Sum();
            price += aquarium.Decorations.Select(decoration => decoration.Price).Sum();
            return String.Format(OutputMessages.AquariumValue, aquariumName, price);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(aquarium => aquarium.Name == aquariumName);
            int count = 0;
            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
                count++;
            }
            return String.Format(OutputMessages.FishFed, count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(aquarium => aquarium.Name == aquariumName);
            IDecoration decoration = this.decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);
            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
