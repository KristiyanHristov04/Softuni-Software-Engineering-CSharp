using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get { return this.Renovators.Count; } }
        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.Renovators = new List<Renovator>();
        }
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (this.Renovators.Count >= this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            this.Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            bool doesExist = false;
            foreach (var renovator in this.Renovators)
            {
                if (renovator.Name == name)
                {
                    doesExist = true;
                    this.Renovators.Remove(renovator);
                    return doesExist;
                }
            }
            return doesExist;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            bool doesExist = this.Renovators.Exists(renovator => renovator.Type == type);
            int count = 0;
            if (doesExist)
            {
                foreach (var renovator in this.Renovators)
                {
                    if (renovator.Type == type)
                    {
                        count++;
                    }
                }
                this.Renovators.RemoveAll(renovator => renovator.Type == type);
                return count;
            }
            else
            {
                return 0;
            }
        }
        public Renovator HireRenovator(string name)
        {
            bool doesExist = this.Renovators.Exists(renovator => renovator.Name == name);
            if (doesExist)
            {
                foreach (var renovator in this.Renovators)
                {
                    if (renovator.Name == name)
                    {
                        renovator.Hired = true;
                        return renovator;
                    }
                }
            }
            return null;
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> workingRenovators = this.Renovators.Where(renovator => renovator.Days >= days).ToList();
            return workingRenovators;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (var renovator in this.Renovators.Where(renovator => renovator.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
