using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite.Interfaces
{
    public interface IRepair
    {
            public string PartName { get; }

            public int HoursWorked { get; }
    }
}
