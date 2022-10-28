using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    using Interfaces;
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            return base.ToString()
                    + Environment.NewLine +
                   $"Code Number: {this.CodeNumber}";
        }
    }
}
