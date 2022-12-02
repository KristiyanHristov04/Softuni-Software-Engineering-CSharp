
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace OnlineShop.Models.Products.Computers
{
    using OnlineShop.Common.Constants;
    using OnlineShop.Models.Products.Components;
    using OnlineShop.Models.Products.Peripherals;


    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override decimal Price
        => base.Price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);

        public override double OverallPerformance
        {
            get
            {
                if (!components.Any())
                    return base.OverallPerformance;
                else
                    return base.OverallPerformance + components.Average(x => x.OverallPerformance);
            }
        }

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType().Name == component.GetType().Name))
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, this.GetType().Name, this.Id));
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType) 
        {            
            if (!components.Any(x => x.GetType().Name == componentType))
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent,
                    componentType, this.GetType().Name, this.Id));
            IComponent componentToRemove = components.Find(x => x.GetType().Name == componentType);
            components.Remove(componentToRemove);
            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!peripherals.Any(x => x.GetType().Name == peripheralType))
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType, this.GetType().Name, this.Id));
            IPeripheral peripheralToRemove = peripherals.Find(x => x.GetType().Name == peripheralType);
            peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({components.Count}):");
            if (components.Any())
                sb.AppendLine(String.Join(Environment.NewLine, components.Select(x => $"  {x}")));

            double averagePerformance = peripherals.Count > 0 ? peripherals.Average(x => x.OverallPerformance) : 0;
            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({averagePerformance:f2}):");
            if (peripherals.Any())
                sb.Append(String.Join(Environment.NewLine, peripherals.Select(x => $"  {x}")));

            return sb.ToString().TrimEnd();
        }
    }
}
