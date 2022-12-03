using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> items;
        public Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
        public int Capacity { get; set; }

        public int Load => this.items.Select(item => item.Weight).Sum();

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = this.items.FirstOrDefault(item => item.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(item);
            return item;
        }
    }
}
