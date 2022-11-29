using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;
        public Dye(int power)
        {
            this.Power = power;
        }
        public int Power 
        {
            get { return this.power; }
            private set
            {
                if (value < 0)
                {
                    this.power = 0;
                }
                this.power = value;
            }
        }

        public bool IsFinished()
        {
            return this.Power == 0;
        }

        public void Use()
        {
            this.Power -= 10;
        }
    }
}
