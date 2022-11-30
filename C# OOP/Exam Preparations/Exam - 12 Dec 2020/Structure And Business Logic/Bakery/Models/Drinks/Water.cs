using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal InitialPrice = 1.50m;
        public Water(string name, int portion, string brand) : base(name, portion, InitialPrice, brand)
        {

        }
    }
}
