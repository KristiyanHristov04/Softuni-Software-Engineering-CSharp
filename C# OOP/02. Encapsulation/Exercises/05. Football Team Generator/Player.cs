using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Football_Team_Generator
{
    public class Player
    {
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        private int endurance;

        public int Endurance
        {
            get { return endurance; }
            private set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Endurance)} should be between 0 and 100.");
                }
                endurance = value;
            }
        }
        private int sprint;

        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Sprint)} should be between 0 and 100.");
                }
                sprint = value;
            }
        }
        private int dribble;

        public int Dribble
        {
            get { return dribble; }
            private set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Dribble)} should be between 0 and 100.");
                }
                dribble = value;
            }
        }
        private int passing;

        public int Passing
        {
            get { return passing; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Passing)} should be between 0 and 100.");
                }
                passing = value;
            }
        }
        private int shooting;

        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Shooting)} should be between 0 and 100.");
                }
                shooting = value;
            }
        }


        public double OverallRate()
           => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
    }
}
