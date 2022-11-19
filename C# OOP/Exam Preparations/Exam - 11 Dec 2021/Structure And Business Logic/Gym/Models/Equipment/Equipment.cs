using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        public double Weight { get; private set; }

        public decimal Price { get; private set; }

        public Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }
    }
}
