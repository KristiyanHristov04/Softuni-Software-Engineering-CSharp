using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int InitalEnergy = 50;
        public SleepyBunny(string name) : base(name, InitalEnergy)
        {

        }

        public override void Work()
        {
            this.Energy -= 15;
        }
    }
}
