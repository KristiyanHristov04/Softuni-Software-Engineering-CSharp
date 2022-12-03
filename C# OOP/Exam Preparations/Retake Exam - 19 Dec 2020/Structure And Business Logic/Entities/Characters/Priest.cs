using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double InitialBaseHealth = 50;
        private const double InitialBaseArmor = 25;
        private const double InitialAbilityPoints = 40;
        public Priest(string name) : base(name, InitialBaseHealth, InitialBaseArmor, InitialAbilityPoints, new Backpack())
        {

        }

        public void Heal(Character character)
        {
            EnsureAlive();
            character.EnsureAlive();
            character.Health += this.AbilityPoints;
        }
    }
}
