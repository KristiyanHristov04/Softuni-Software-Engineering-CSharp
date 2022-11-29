using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            switch (bunnyType)
            {
                case "HappyBunny":
                    bunny = new HappyBunny(bunnyName);
                    break;
                case "SleepyBunny":
                    bunny = new SleepyBunny(bunnyName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            this.bunnies.Add(bunny);
            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            Dye dye = new Dye(power);
            bunny.AddDye(dye);
            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            Egg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);
            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            Workshop workshop = new Workshop();
            IEgg egg = this.eggs.FindByName(eggName);
            int readyBunnies = 0;
            foreach (var bunny in this.bunnies.Models.Where(bunny => bunny.Energy >= 50).OrderByDescending(bunny => bunny.Energy))
            {
                readyBunnies++;
                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    this.bunnies.Remove(bunny);
                }
            }


            if (readyBunnies == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            if (egg.IsDone())
            {
                return String.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return String.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            int doneEggs = this.eggs.Models.Where(egg => egg.IsDone()).Count();
            sb.AppendLine($"{doneEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in this.bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Where(dye => !dye.IsFinished()).Count()} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
