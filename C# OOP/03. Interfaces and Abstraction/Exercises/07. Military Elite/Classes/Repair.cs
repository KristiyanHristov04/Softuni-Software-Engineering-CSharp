﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    using Interfaces;
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }

        public string PartName { get; }

        public int HoursWorked { get; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
