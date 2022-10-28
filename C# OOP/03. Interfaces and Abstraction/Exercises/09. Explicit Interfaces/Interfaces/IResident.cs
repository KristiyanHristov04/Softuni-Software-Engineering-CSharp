using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Interfaces
{
    public interface IResident
    {
        public string Name { get;}
        public string Country { get;}
        void GetName();
    }
}
