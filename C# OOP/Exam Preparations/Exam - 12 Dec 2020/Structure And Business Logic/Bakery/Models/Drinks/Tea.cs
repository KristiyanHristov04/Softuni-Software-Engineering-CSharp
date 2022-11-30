using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public class Tea : Drink
    {
        private const decimal InitialPrice = 2.50m;
        public Tea(string name, int portion, string brand) : base(name, portion, InitialPrice, brand)
        {

        }
    }
}
