using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> vessels;
        public VesselRepository()
        {
            this.vessels = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => this.vessels;

        public void Add(IVessel model)
        {
            this.vessels.Add(model);
        }

        public IVessel FindByName(string name)
        {
            return this.vessels.FirstOrDefault(vessel => vessel.Name == name);
        }

        public bool Remove(IVessel model)
        {
            return this.vessels.Remove(model);
        }
    }
}
