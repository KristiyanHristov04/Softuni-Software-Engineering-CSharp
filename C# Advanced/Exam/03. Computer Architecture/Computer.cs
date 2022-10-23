using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public List<CPU> Multiprocessor { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Multiprocessor.Count; } }
        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }
        public void Add(CPU cpu)
        {
            if (this.Multiprocessor.Count + 1 <= this.Capacity)
            {
                this.Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            bool doesExist = false;
            foreach (CPU cpu in this.Multiprocessor)
            {
                if (cpu.Brand == brand)
                {
                    doesExist = true;
                    this.Multiprocessor.Remove(cpu);
                    return doesExist;
                }
            }
            return doesExist;
        }
        public CPU MostPowerful()
        {
            if (this.Multiprocessor.Count > 0)
            {
                CPU mostPowerfulCPU = this.Multiprocessor.OrderByDescending(cpu => cpu.Frequency).First();
                return mostPowerfulCPU;
            }
            return null;
        }
        public CPU GetCPU(string brand)
        {
            foreach (var cpu in this.Multiprocessor)
            {
                if (cpu.Brand == brand)
                {
                    return cpu;
                }
            }
            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {this.Model}:");
            foreach (var cpu in this.Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
