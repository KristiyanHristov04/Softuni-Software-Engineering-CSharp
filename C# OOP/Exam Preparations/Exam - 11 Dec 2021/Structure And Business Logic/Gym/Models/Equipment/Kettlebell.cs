using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double Weight = 10_000;
        private const decimal Price = 80;
        public Kettlebell() : base(Weight, Price)
        {

        }
    }
}
