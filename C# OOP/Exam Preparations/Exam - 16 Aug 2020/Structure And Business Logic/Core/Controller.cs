using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Core
{
    using Models.Products.Computers;
    using OnlineShop.Common.Constants;
    using OnlineShop.Models.Products.Components;
    using OnlineShop.Models.Products.Peripherals;    
    using System.Linq;

    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IPeripheral> peripherals;
        private List<IComponent> components;

        public Controller()
        {
            computers = new List<IComputer>();
            peripherals = new List<IPeripheral>();
            components = new List<IComponent>();
        }

        private IComputer FindComputerById(int id)
        {
            IComputer computer = computers.Find(x => x.Id == id);
            if (computer == null)
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            return computer;
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = FindComputerById(computerId);
            if (components.Any(x => x.Id == id))
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            IComponent component;
            switch (componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation); break;
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation); break;
                case "PowerSupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation); break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation); break;
                case "SolidStateDrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation); break;
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            computer.AddComponent(component);
            components.Add(component);
            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            IComputer computer;
            switch (computerType)
            {
                case "DesktopComputer": computer = new DesktopComputer(id, manufacturer, model, price); break;
                case "Laptop": computer = new Laptop(id, manufacturer, model, price); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = FindComputerById(computerId);
            if (peripherals.Any(x => x.Id == id))
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);

            IPeripheral peripheral;
            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);
            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer computerTobuy = computers.Where(x => x.Price <= budget).OrderByDescending(x => x.Price).FirstOrDefault();
            if (computerTobuy == null)
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            computers.Remove(computerTobuy);
            return computerTobuy.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = FindComputerById(id);
            computers.Remove(computer);
            if (computer != null)
                return computer.ToString();
            else
                return String.Empty;
        }

        public string GetComputerData(int id)
        {
            IComputer computer = FindComputerById(id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = FindComputerById(computerId);
            IComponent component = computer.RemoveComponent(componentType);
            components.Remove(component);
            if (component != null)
                return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
            else
                return String.Empty;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = FindComputerById(computerId);
            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);
            if (peripheral != null)
                return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
            else
                return string.Empty;
        }
    }
}
