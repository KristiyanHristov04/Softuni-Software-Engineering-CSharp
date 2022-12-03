using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int InitialWeight = 5;
        public HealthPotion() : base(InitialWeight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= 20;

            if (character.Health <= 0)
                character.IsAlive = false;
        }
    }
}
