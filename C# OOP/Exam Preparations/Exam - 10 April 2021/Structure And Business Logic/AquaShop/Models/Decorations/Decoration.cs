using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;

        protected Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }

        public int Comfort 
        { 
            get { return this.comfort; }
            private set
            {
                this.comfort = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                this.price = value;
            }
        }
    }
}
