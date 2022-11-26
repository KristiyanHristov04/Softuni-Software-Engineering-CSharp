using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;
        private const double InitialArmorThickness = 200;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {

        }

        public bool SubmergeMode 
        {
            get { return this.submergeMode; }
            private set
            {
                this.submergeMode = value;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < InitialArmorThickness)
            {
                this.ArmorThickness = InitialArmorThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (!this.SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
                this.SubmergeMode = true;
            }
            else if (this.SubmergeMode)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
                this.SubmergeMode = false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string submergeModeText = this.SubmergeMode ? "ON" : "OFF";
            sb.AppendLine(Environment.NewLine + $" *Submerge mode: {submergeModeText}");
            return base.ToString() + sb.ToString().TrimEnd();
        }
    }
}
