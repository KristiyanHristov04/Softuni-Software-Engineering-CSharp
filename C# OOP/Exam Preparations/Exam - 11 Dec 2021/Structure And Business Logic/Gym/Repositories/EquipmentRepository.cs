using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    internal class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> models;
        public IReadOnlyCollection<IEquipment> Models => this.models;

        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }

        public void Add(IEquipment model)
        {
            this.models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            IEquipment equipment = this.models.FirstOrDefault(eq => eq.GetType().Name == type);
            return equipment;
        }

        public bool Remove(IEquipment model)
        {
            return this.models.Remove(model);
        }
    }
}
