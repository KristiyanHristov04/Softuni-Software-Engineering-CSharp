using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    using Entities.Characters.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using Entities.Characters;
    using Entities.Items;

    public class WarController
    {
        private List<Character> characters;
        private Stack<Item> items;

        public WarController()
        {
            characters = new List<Character>();
            items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            Character character;
            switch (characterType)
            {
                case "Warrior": character = new Warrior(name); break;
                case "Priest": character = new Priest(name); break;
                default: throw new ArgumentException(String.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
            characters.Add(character);
            return String.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item;
            switch (itemName)
            {
                case "HealthPotion": item = new HealthPotion(); break;
                case "FirePotion": item = new FirePotion(); break;
                default: throw new ArgumentException(String.Format(ExceptionMessages.InvalidItem, itemName));
            }
            items.Push(item);
            return String.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = characters.Find(x => x.Name == characterName);

            if (character == null)
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            if (!items.Any())
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);

            Item item = items.Pop();
            character.Bag.AddItem(item);
            return String.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = characters.Find(x => x.Name == characterName);
            if (character == null)
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return String.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            Func<Character, string> printChar = (Character x) =>
            {
                string status = x.IsAlive ? "Alive" : "Dead";
                return $"{x.Name} - HP: {x.Health}/{x.BaseHealth}, AP: {x.Armor}/{x.BaseArmor}, Status: {status}";
            };
            return string.Join(Environment.NewLine, characters.OrderByDescending(x => x.Health).Select(printChar));
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = characters.Find(x => x.Name == attackerName);
            Character receiver = characters.Find(x => x.Name == receiverName);

            if (attacker == null)
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            if (receiver == null)
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            if (attacker.GetType() != typeof(Warrior))
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attackerName));

            (attacker as Warrior).Attack(receiver);

            string output = String.Format(SuccessMessages.AttackCharacter,
                attackerName, receiverName, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor);
            if (!receiver.IsAlive)
                output += Environment.NewLine + String.Format(SuccessMessages.AttackKillsCharacter, receiverName);
            return output;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = characters.Find(x => x.Name == healerName);
            Character receiver = characters.Find(x => x.Name == healingReceiverName);

            if (healer == null)
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healerName));
            if (receiver == null)
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            if (healer.GetType() != typeof(Priest))
                throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));

            (healer as Priest).Heal(receiver);

            return String.Format(SuccessMessages.HealCharacter,
                healerName, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);
        }
    }
}
