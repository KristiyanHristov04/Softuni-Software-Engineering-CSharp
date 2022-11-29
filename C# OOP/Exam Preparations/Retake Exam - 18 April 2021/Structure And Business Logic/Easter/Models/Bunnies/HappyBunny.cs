using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int InitalEnergy = 100;
        public HappyBunny(string name) : base(name, InitalEnergy)
        {

        }

        public override void Work()
        {
            this.Energy -= 10;
        }
    }
}
