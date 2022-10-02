using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return Drones.Count; } }

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }

            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (Drones.Count + 1 > Capacity)
            {
                return "Airfield is full.";
            }

            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            bool doesExist = Drones.Exists(drone => drone.Name == name);
            if (doesExist)
            {
                Drones.RemoveAll(drone => drone.Name == name);
                return doesExist;
            }
            else
            {
                return doesExist;
            }
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = Drones.Count(drone => drone.Brand == brand);
            if (count > 0)
            {
                Drones.RemoveAll(drone => drone.Brand == brand);
                return count;
            }
            else
            {
                return 0;
            }
        }

        public Drone FlyDrone(string name)
        {
            bool doesExist = Drones.Exists(drone => drone.Name == name);
            if (doesExist)
            {
                foreach (var drone in Drones)
                {
                    if (drone.Name == name)
                    {
                        drone.Available = false;
                        return drone;
                    }
                }
            }
            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> meetingConditionDrones = Drones.Where(drone => drone.Range >= range).ToList();
            foreach (var drone in Drones)
            {
                if (drone.Range >= range)
                {
                    drone.Available = false;
                }
            }
            return meetingConditionDrones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            List<Drone> notInFlight = Drones.Where(drone => drone.Available == true).ToList();
            foreach (var drone in notInFlight)
            {
                sb.AppendLine(drone.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
