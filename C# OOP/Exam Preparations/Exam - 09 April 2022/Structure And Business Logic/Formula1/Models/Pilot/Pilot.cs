using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Pilot
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private bool canRace = false;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }
        public string FullName 
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPilot, value));
                }
                this.fullName = value;
            }
        }

        public IFormulaOneCar Car 
        {
            get { return this.car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                this.car = value;
            }
        }

        public int NumberOfWins {get; private set; }

        public bool CanRace => this.canRace;

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.canRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
