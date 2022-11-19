using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public class Gym : IGym
    {
        private ICollection<IEquipment> allEquipment;
        private ICollection<IAthlete> allAthletes;
        private string name;
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }
        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.allEquipment = new List<IEquipment>();
            this.allAthletes = new List<IAthlete>();
        }

        public double EquipmentWeight => this.allEquipment.Sum(currentEquipment => currentEquipment.Weight);

        public ICollection<IEquipment> Equipment => this.allEquipment;

        public ICollection<IAthlete> Athletes => this.allAthletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.allAthletes.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            this.allAthletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.allEquipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.allAthletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            if (this.allAthletes.Count > 0)
            {
                string athletesNamesInfo = string.Join(", ", this.allAthletes.Select(athlete => athlete.FullName));
                sb.Append("Athletes: ");
                sb.AppendLine(athletesNamesInfo);
            }
            else
            {
                sb.AppendLine("Athletes: No athletes");
            }
            sb.AppendLine($"Equipment total count: {this.allEquipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.allAthletes.Remove(athlete);
        }
    }
}
