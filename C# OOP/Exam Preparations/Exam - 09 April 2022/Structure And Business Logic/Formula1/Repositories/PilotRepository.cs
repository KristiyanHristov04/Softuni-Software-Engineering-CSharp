using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots;
        public PilotRepository()
        {
            this.pilots = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => this.pilots;

        public void Add(IPilot model)
        {
            this.pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return this.pilots.FirstOrDefault(pilot => pilot.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return this.pilots.Remove(model);
        }
    }
}
