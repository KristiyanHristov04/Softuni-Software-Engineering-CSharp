using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasterRaces.Models.Drivers.Entities;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;
        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.drivers.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            ICar car = this.cars.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            return String.Format(OutputMessages.CarAdded, driverName, car.Model);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            IDriver driver = this.drivers.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return String.Format(OutputMessages.DriverAdded, driverName, race.Name);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = this.cars.GetByName(model);
            if (car != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            }

            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
            }

            this.cars.Add(car);
            return String.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = this.drivers.GetByName(driverName);
            if (driver != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
            }
            driver = new Driver(driverName);
            this.drivers.Add(driver);
            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.races.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }
            race = new Race(name, laps);
            this.races.Add(race);
            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            StringBuilder sb = new StringBuilder();
            IRace race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            int counter = 1;
            foreach (var driver in race.Drivers.OrderByDescending(driver => driver.Car.CalculateRacePoints(race.Laps)).Take(3))
            {
                if (counter == 1)
                {
                    sb.AppendLine($"Driver {driver.Name} wins {raceName} race.");
                }
                else if (counter == 2)
                {
                    sb.AppendLine($"Driver {driver.Name} is second in {raceName} race.");
                }
                else if (counter == 3)
                {
                    sb.AppendLine($"Driver {driver.Name} is third in {raceName} race.");
                }
                counter++;
            }

            this.races.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
