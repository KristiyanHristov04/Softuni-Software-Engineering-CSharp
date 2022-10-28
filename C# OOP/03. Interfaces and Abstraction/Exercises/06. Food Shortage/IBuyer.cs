using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IBuyer
    {
        void BuyFood();
        public int Food { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; }
    }
}
