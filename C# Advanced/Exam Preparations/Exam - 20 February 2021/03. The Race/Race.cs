using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public List<Racer> Racers { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Racers.Count; } }
        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Racers = new List<Racer>();
        }
        public void Add(Racer racer)
        {
            if (this.Racers.Count + 1 <= this.Capacity)
            {
                this.Racers.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            bool doesExist = false;
            foreach (var racer in this.Racers)
            {
                if (racer.Name == name)
                {
                    this.Racers.Remove(racer);
                    doesExist = true;
                    return doesExist;
                }
            }
            return doesExist;
        }
        public Racer GetOldestRacer()
        {
            Racer oldestRacer = this.Racers.OrderByDescending(racer => racer.Age).First();
            return oldestRacer;
        }
        public Racer GetRacer(string name)
        {
            Racer racer = this.Racers.Where(racer => racer.Name == name).First();
            return racer;
        }
        public Racer GetFastestRacer()
        {
            Racer fastestRacer = this.Racers.OrderByDescending(racer => racer.Car.Speed).First();
            return fastestRacer;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in this.Racers)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
