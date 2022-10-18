using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; set; }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Fish.Count; } }
        public Net(string material, int capacity)
        {
            this.Material = material;
            Capacity = capacity;
            this.Fish = new List<Fish>();   
        }
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) ||
                fish.Weight <= 0 || fish.Length <= 0)
            {
                return "Invalid fish.";
            }
            if (this.Fish.Count + 1 > this.Capacity)
            {
                return "Fishing net is full.";
            }
            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            bool doesExist = false;
            foreach (var fish in this.Fish)
            {
                if (fish.Weight == weight)
                {
                    doesExist = true;
                    this.Fish.Remove(fish);
                    return doesExist;
                }
            }
            return doesExist;
        }
        public Fish GetFish(string fishType)
        {
            return this.Fish.Where(fish => fish.FishType == fishType).First();
        }
        public Fish GetBiggestFish()
        {
            return this.Fish.OrderByDescending(fish => fish.Length).First();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");
            foreach (var fish in this.Fish.OrderByDescending(fish => fish.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
