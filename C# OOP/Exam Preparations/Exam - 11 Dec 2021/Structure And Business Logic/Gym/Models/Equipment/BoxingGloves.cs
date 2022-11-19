using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double Weight = 227;
        private const decimal Price = 120;
        public BoxingGloves() : base(Weight, Price)
        {

        }
    }
}
