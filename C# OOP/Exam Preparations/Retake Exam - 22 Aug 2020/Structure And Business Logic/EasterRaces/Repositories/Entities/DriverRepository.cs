using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> drivers;
        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }
        public void Add(IDriver model)
        {
            this.drivers.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.drivers;
        }

        public IDriver GetByName(string name)
        {
            return this.drivers.FirstOrDefault(driver => driver.Name == name);
        }

        public bool Remove(IDriver model)
        {
            return this.drivers.Remove(model);
        }
    }
}
