using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Interfaces
{
    public interface IPerson
    {
        public string Name { get;}
        public string Country { get;}
        void GetName();
    }
}
