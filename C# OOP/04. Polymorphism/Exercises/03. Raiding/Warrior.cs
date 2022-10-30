using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            this.Power = 100;
        }
        public override void CastAbility()
        {
            Console.WriteLine($"{GetType().Name} - {this.Name} hit for {this.Power} damage");
        }
    }
}
