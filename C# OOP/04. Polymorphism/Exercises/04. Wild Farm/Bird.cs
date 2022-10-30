using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; set; }
        public Bird(string name, double weight, double WingSize) : base(name, weight)
        {
            this.WingSize = WingSize;
        }
    }
}
