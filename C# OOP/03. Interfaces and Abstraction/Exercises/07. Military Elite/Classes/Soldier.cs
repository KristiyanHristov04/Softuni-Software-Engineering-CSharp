using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public abstract class Soldier : ISoldier
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public Soldier(int id, string name, string lastName)
        {
            this.Id = id;
            this.FirstName = name;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
