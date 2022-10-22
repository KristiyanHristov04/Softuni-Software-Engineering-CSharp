using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        public string Brand { get; set; }
        public int Cores { get; set; }
        public double Frequency { get; set; }
        public CPU(string brand, int cores, double frequency)
        {
            this.Brand = brand;
            this.Cores = cores;
            this.Frequency = frequency;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.Brand} CPU:");
            stringBuilder.AppendLine($"Cores: {this.Cores}");
            stringBuilder.AppendLine($"Frequency: {this.Frequency:f1} GHz");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
