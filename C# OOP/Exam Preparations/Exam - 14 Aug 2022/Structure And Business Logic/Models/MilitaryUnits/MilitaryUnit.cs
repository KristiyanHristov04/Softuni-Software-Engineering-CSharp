using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class MilitaryUnit : IMilitaryUnit
    {
        private int enduranceLevel = 1;
        public double Cost {get; private set;}

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
        }
        public int EnduranceLevel 
        {
            get { return this.enduranceLevel; }
            private set
            {
                if (value > 20)
                {
                    this.enduranceLevel = 20;
                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }
                this.enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;
        }
    }
}
