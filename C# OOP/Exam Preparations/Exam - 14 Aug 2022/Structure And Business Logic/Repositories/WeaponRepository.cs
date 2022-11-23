using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;
        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.models;

        public void AddItem(IWeapon model)
        {
            this.models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.models.FirstOrDefault(weapon => weapon.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            IWeapon weapon = this.models.FirstOrDefault(weapon => weapon.GetType().Name == name);
            return this.models.Remove(weapon);
        }
    }
}
