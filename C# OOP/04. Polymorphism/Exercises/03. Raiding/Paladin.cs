using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
            this.Power = 100;
        }
        public override void CastAbility()
        {
            Console.WriteLine($"{GetType().Name} - {this.Name} healed for {this.Power}");
        }
    }
}
