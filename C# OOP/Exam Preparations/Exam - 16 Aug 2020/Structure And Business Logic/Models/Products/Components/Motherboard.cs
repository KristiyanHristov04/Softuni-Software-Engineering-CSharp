﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    internal class Motherboard : Component
    {
        private const double MULTIPLIER = 1.25;

        public Motherboard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance * MULTIPLIER, generation)
        { }
    }
}
