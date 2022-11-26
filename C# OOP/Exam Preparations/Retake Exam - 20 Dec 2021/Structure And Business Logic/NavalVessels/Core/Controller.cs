using NavalVessels.Core.Contracts;
using NavalVessels.Models.Captain;
using NavalVessels.Models.Contracts;
using NavalVessels.Models.Vessels;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;
        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(captain => captain.FullName == selectedCaptainName);
            if (captain == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            IVessel vessel = this.vessels.FindByName(selectedVesselName);
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            vessel.Captain = captain;
            captain.Vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = this.vessels.FindByName(attackingVesselName);
            if (attacker == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (attacker.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            IVessel defender = this.vessels.FindByName(defendingVesselName);
            if (defender == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            if (defender.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();
            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defender.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = this.captains.FirstOrDefault(captain => captain.FullName == captainFullName);
            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain newCaptain = new Captain(fullName);
            if (captains.Any(x => x.FullName == fullName))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            this.captains.Add(newCaptain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = this.vessels.FindByName(name);
            if (vessel != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            switch (vesselType)
            {
                case "Submarine":
                    vessel = new Submarine(name, mainWeaponCaliber, speed);
                    break;
                case "Battleship":
                    vessel = new Battleship(name, mainWeaponCaliber, speed);
                    break;
                default:
                    return String.Format(OutputMessages.InvalidVesselType);
            }

            this.vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vesselToToggle = vessels.FindByName(vesselName);
            if (vesselToToggle == null)
                return String.Format(OutputMessages.VesselNotFound, vesselName);

            if (vesselToToggle.GetType().Name == "Battleship")
            {
                (vesselToToggle as Battleship).ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                (vesselToToggle as Submarine).ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);
            return vessel.ToString();
        }
    }
}
