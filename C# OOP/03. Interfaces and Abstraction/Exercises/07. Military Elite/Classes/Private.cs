using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public class Private : Soldier, ISoldier, IPrivate
    {
        public decimal Salary { get; private set; }
        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }
        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:F2}";
        }
    }
}
