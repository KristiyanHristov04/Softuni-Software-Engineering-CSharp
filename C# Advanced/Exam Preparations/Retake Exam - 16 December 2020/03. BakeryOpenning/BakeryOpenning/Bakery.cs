using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public List<Employee> Employees { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Employees.Count; } }
        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Employees = new List<Employee>();
        }
        public void Add(Employee employee)
        {
            if (this.Employees.Count + 1 <= this.Capacity)
            {
                this.Employees.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            bool doesExist = false;
            foreach (var employee in this.Employees)
            {
                if (employee.Name == name)
                {
                    doesExist = true;
                    this.Employees.Remove(employee);
                    return doesExist;
                }
            }
            return doesExist;
        }
        public Employee GetOldestEmployee()
        {
            Employee oldestEmployee = this.Employees.OrderByDescending(employee => employee.Age).First();
            return oldestEmployee;
        }
        public Employee GetEmployee(string name)
        {
            Employee employee = this.Employees.Where(emp => emp.Name == name).First();
            return employee;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var employee in this.Employees)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
