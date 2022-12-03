using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double InitialBaseHealth = 100;
        private const double InitialBaseArmor = 50;
        private const double InitialAbilityPoints = 40;
        public Warrior(string name) : base(name, InitialBaseHealth, InitialBaseArmor, InitialAbilityPoints, new Satchel())
        {

        }
        public void Attack(Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            if (character.Equals(this))
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            character.TakeDamage(this.AbilityPoints);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
