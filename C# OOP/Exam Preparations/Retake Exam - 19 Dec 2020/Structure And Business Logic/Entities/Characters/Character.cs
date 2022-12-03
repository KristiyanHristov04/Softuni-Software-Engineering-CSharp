using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		// TODO: Implement the rest of the class.
		private string name;
        private double health;
        private double armor;
        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.IsAlive = true;
        }
        public string Name 
		{
            get { return this.name; }
			private set
            {
				if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
				this.name = value;
            }
		}

        public double BaseHealth { get; private set; }
        public double Health
        {
            get { return this.health; }
            set
            {
                if (value < 0)
                {
                    this.health = 0;
                }
                else if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else
                {
                    this.health = value;
                }
            }
        }
        public double BaseArmor { get; private set; }
        public double Armor
        {
            get { return this.armor; }
            private set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    this.armor = value;
                }
            }
        }
        public double AbilityPoints { get; private set; }
        public IBag Bag { get; private set; }
        public bool IsAlive { get; set; }

        public void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            double damageToTake = hitPoints;
            double armorBeforeHitPoints = this.Armor;
            this.Armor -= damageToTake;
            damageToTake -= armorBeforeHitPoints;

            if (damageToTake > 0)
            {
                this.Health -= damageToTake;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            //Maybe this item should be removed when used
            item.AffectCharacter(this);
        }
	}
}