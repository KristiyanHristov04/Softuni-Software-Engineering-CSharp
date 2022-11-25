using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => this.races;

        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public IRace FindByName(string name)
        {
            return this.races.FirstOrDefault(race => race.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }
    }
}
