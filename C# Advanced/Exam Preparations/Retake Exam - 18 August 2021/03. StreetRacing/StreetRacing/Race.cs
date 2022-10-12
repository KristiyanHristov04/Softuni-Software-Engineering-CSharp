using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count { get { return this.Participants.Count; } }
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }
        public void Add(Car car)
        {
            bool doesCarWithThisPlateExists = this.Participants.Exists(currCar => currCar.LicensePlate == car.LicensePlate);
            if (!doesCarWithThisPlateExists && car.HorsePower <= this.MaxHorsePower && this.Participants.Count + 1 <= this.Capacity)
            {
                this.Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            bool doesExist = false;
            foreach (Car car in this.Participants)
            {
                if (car.LicensePlate == licensePlate)
                {
                    doesExist = true;
                    this.Participants.Remove(car);
                    return doesExist;
                }
            }
            return doesExist;
        }
        public Car FindParticipant(string licensePlate)
        {
            foreach (var car in this.Participants)
            {
                if (car.LicensePlate == licensePlate)
                {
                    return car;
                }
            }
            return null;
        }
        public Car GetMostPowerfulCar()
        {
            if (this.Participants.Count > 0)
            {
                Car mostPowerfulCar = this.Participants.OrderByDescending(car => car.HorsePower).First();
                return mostPowerfulCar;
            }
            else
            {
                return null;
            }
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (var car in this.Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
