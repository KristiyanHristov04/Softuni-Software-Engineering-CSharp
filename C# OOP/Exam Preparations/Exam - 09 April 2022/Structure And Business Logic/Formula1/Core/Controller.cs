using Formula1.Core.Contracts;
using Formula1.Models.Contracts;
using Formula1.Models.Formulas;
using Formula1.Models.Pilot;
using Formula1.Models.Race;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotName);
            if (pilot == null || pilot.CanRace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar car = this.carRepository.FindByName(carModel);
            if (car == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            this.carRepository.Remove(car);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = this.pilotRepository.FindByName(pilotFullName);
            bool isPilotAlreadyInTheRace = false;
            foreach (var pilot_ in race.Pilots)
            {
                if (pilot_ == pilot)
                {
                    isPilotAlreadyInTheRace = true;
                    break;
                }
            }

            if (pilot == null || !pilot.CanRace || isPilotAlreadyInTheRace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = this.carRepository.FindByName(model);
            if (car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            switch (type)
            {
                case "Ferrari":
                    car = new Ferrari(model, horsepower, engineDisplacement);
                    break;
                case "Williams":
                    car = new Williams(model, horsepower, engineDisplacement);
                    break;
                default:
                    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            this.carRepository.Add(car);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = this.pilotRepository.FindByName(fullName);
            if (pilot != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilot = new Pilot(fullName);
            this.pilotRepository.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            race = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(race);
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pilot in this.pilotRepository.Models.OrderByDescending(pilot => pilot.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var race in this.raceRepository.Models)
            {
                if (race.TookPlace)
                {
                    sb.AppendLine(race.RaceInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            StringBuilder sb = new StringBuilder();
            int counter = 1;
            foreach (var pilot in race.Pilots.OrderByDescending(pilot => pilot.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3))
            {
                if (counter == 1)
                {
                    sb.AppendLine($"Pilot {pilot.FullName} wins the {raceName} race.");
                    pilot.WinRace();
                }
                else if (counter == 2)
                {
                    sb.AppendLine($"Pilot {pilot.FullName} is second in the {raceName} race.");
                }
                else if (counter == 3)
                {
                    sb.AppendLine($"Pilot {pilot.FullName} is third in the {raceName} race.");
                }
                counter++;
            }

            race.TookPlace = true;
            return sb.ToString().TrimEnd();
        }
    }
}
