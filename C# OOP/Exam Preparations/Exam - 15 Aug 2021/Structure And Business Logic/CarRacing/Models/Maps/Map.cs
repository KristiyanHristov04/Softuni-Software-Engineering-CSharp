using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            double racerOneRacingBeheviorValue = 0;
            switch (racerOne.RacingBehavior)
            {
                case "strict":
                    racerOneRacingBeheviorValue = 1.2;
                    break;
                case "aggressive":
                    racerOneRacingBeheviorValue = 1.1;
                    break;
            }
            double racerOneChancesOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneRacingBeheviorValue;

            double racerTwoRacingBeheviorValue = 0;
            switch (racerTwo.RacingBehavior)
            {
                case "strict":
                    racerTwoRacingBeheviorValue = 1.2;
                    break;
                case "aggressive":
                    racerTwoRacingBeheviorValue = 1.1;
                    break;
            }
            double racerTwoChancesOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoRacingBeheviorValue;

            if (racerOneChancesOfWinning > racerTwoChancesOfWinning)
            {
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
        }
    }
}
