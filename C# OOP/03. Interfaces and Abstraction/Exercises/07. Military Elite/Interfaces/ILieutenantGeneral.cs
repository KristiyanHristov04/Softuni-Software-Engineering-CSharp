using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        public Dictionary<int, IPrivate> Privates { get; }
    }
}
