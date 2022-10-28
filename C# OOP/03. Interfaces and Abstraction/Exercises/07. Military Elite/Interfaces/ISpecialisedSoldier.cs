using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite.Interfaces
{
    using Enums;
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
