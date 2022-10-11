using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public List<Car> Cars { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Cars.Count; } }
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Cars = new List<Car>();
        }
        public void Add(Car car)
        {
            if (this.Cars.Count + 1 <= this.Capacity)
            {
                this.Cars.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            bool doesExist = false;
            foreach (var car in this.Cars)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    this.Cars.Remove(car);
                    doesExist = true;
                    return doesExist;
                }
            }
            return doesExist;
        }
        public Car GetLatestCar()
        {
            if (this.Cars.Count > 0)
            {
                Car latestCar = this.Cars.OrderByDescending(car => car.Year).First();
                return latestCar;
            }
            else
            {
                return null;
            }
        }
        public Car GetCar(string manufacturer, string model)
        {
            bool doesExist = this.Cars.Exists(car => car.Manufacturer == manufacturer && car.Model == model);
            if (doesExist)
            {
                Car car = this.Cars.Where(car => car.Manufacturer == manufacturer && car.Model == model).First();
                return car;
            }
            else
            {
                return null;
            }
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in this.Cars)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
