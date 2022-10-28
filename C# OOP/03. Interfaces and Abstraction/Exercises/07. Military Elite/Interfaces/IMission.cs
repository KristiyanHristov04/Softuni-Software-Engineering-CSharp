using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite.Interfaces
{
    using Enums;
    public interface IMission
    {
        public string CodeName { get; }

        public State State { get; }

        public void CompleteMission();
    }
}
