using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            this.Power = 80;
        }
        public override void CastAbility()
        {
            Console.WriteLine($"{GetType().Name} - {this.Name} healed for {this.Power}");
        }
    }
}
