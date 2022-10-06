using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        public List<Ski> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Data.Count; } }
        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Data = new List<Ski>();
        }
        public void Add(Ski ski)
        {
            if (this.Data.Count + 1 <= this.Capacity)
            {
                this.Data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            bool doesExist = false;
            foreach (var ski in this.Data)
            {
                if (ski.Manufacturer == manufacturer && ski.Model == model)
                {
                    doesExist = true;
                    this.Data.Remove(ski);
                    return doesExist;
                }
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            if (this.Data.Count == 0)
            {
                return null;
            }
            return this.Data.OrderByDescending(ski => ski.Year).First();
        }
        public Ski GetSki(string manufacturer, string model)
        {
            foreach (var ski in this.Data)
            {
                if (ski.Manufacturer == manufacturer && ski.Model == model)
                {
                    return ski;
                }
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var ski in this.Data)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
