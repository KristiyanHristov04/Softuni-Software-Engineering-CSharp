using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        //private readonly List<IMilitaryUnit> militaryUnits;
        //private readonly List<IWeapon> weapons;
        private UnitRepository militaryUnits;
        private WeaponRepository weapons;
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            //this.militaryUnits = new List<IMilitaryUnit>();
            //this.weapons = new List<IWeapon>();
            this.militaryUnits = new UnitRepository();
            this.weapons = new WeaponRepository();
        }
        public string Name 
        {
            get { return this.name; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public double Budget 
        {
            get { return this.budget;}
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => this.militaryUnits.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            //this.militaryUnits.Add(unit);
            this.militaryUnits.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            //this.weapons.Add(weapon);
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");

            if (this.militaryUnits.Models.Count > 0)
            {
                string militaryUnitsJoined = string.Join(", ", militaryUnits.Models.Select(x => x.GetType().Name));
                sb.AppendLine("--Forces: " + militaryUnitsJoined);
            }
            else
            {
                sb.AppendLine("--Forces: No units");
            }

            if (this.weapons.Models.Count > 0)
            {
                string weaponsJoined = string.Join(", ", weapons.Models.Select(x => x.GetType().Name));
                sb.AppendLine("--Combat equipment: " + weaponsJoined);
            }
            else
            {
                sb.AppendLine("--Combat equipment: No weapons");
            }

            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in this.militaryUnits.Models)
            {
                unit.IncreaseEndurance();
            }
        }

        private double CalculateMilitaryPower()
        {
            double totalAmount = this.militaryUnits.Models.Select(unit => unit.EnduranceLevel).Sum() + this.weapons.Models.Select(weapon => weapon.DestructionLevel).Sum();
            if (this.militaryUnits.Models.FirstOrDefault(unit => unit.GetType().Name == "AnonymousImpactUnit") != null)
            {
                totalAmount += totalAmount * 0.30;
            }
            if (this.weapons.Models.FirstOrDefault(weapon => weapon.GetType().Name == "NuclearWeapon") != null)
            {
                totalAmount += totalAmount * 0.45;
            }

            return totalAmount = Math.Round(totalAmount, 3);
        }
    }
}
