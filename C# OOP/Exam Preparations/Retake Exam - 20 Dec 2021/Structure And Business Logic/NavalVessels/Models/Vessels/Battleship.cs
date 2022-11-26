using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;
        private const double InitialArmorThickness = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {

        }
        public bool SonarMode 
        {
            get { return this.sonarMode; }
            private set
            {
                this.sonarMode = value;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < InitialArmorThickness)
            {
                this.ArmorThickness = InitialArmorThickness;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string sonarModeText = this.SonarMode ? "ON" : "OFF";
            sb.AppendLine(Environment.NewLine + $" *Sonar mode: {sonarModeText}");
            return base.ToString() + sb.ToString().TrimEnd();
        }

        public void ToggleSonarMode()
        {
            if (!this.SonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
                this.SonarMode = true;
            }
            else if (this.SonarMode)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
                this.SonarMode = false;
            }
        }
    }
}
