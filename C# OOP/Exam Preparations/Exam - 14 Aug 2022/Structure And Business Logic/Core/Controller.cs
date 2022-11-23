using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            this.planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (unitTypeName != "AnonymousImpactUnit" && unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            IMilitaryUnit unit = planet.Army.FirstOrDefault(unit => unit.GetType().Name == unitTypeName);
            if (unit != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else if(unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (weaponTypeName != "BioChemicalWeapon" && weaponTypeName != "SpaceMissiles" && weaponTypeName != "NuclearWeapon")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            IWeapon weapon = planet.Weapons.FirstOrDefault(weapon => weapon.GetType().Name == weaponTypeName);
            if (weapon != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = planets.FindByName(name);
            if (planet != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }
            planet = new Planet(name, budget);
            this.planets.AddItem(planet);
            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in this.planets.Models.OrderByDescending(planet => planet.MilitaryPower).ThenBy(planet => planet.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var attacker = planets.FindByName(planetOne);
            var defender = planets.FindByName(planetTwo);

            bool attackerIsNuclear = attacker.Weapons.Any(w => w is NuclearWeapon);
            bool defenderIsNuclear = defender.Weapons.Any(w => w is NuclearWeapon);
            IPlanet winner = null;
            IPlanet looser = null;
            if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                winner = attacker;
                looser = defender;
            }
            else if (defender.MilitaryPower > attacker.MilitaryPower)
            {
                winner = defender;
                looser = attacker;
            }
            else
            {
                if (attackerIsNuclear && !defenderIsNuclear)
                {
                    winner = attacker;
                    looser = defender;
                }
                else if (defenderIsNuclear && !attackerIsNuclear)
                {
                    winner = defender;
                    looser = attacker;
                }
                else
                {
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(looser.Budget / 2);
            winner.Profit(looser.Army.Sum(u => u.Cost) + looser.Weapons.Sum(w => w.Price));

            planets.RemoveItem(looser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            planet.Spend(1.25);
            planet.TrainArmy();
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
