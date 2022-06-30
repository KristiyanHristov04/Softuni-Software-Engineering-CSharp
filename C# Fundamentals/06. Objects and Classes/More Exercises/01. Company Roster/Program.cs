using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (!departments.Any(d => d.DepartmentName == input[2]))
                {
                    departments.Add(new Department(input[2]));
                }

                departments.Find(d => d.DepartmentName == input[2]).AddNewEmployee(input[0], double.Parse(input[1]));
            }

            Department bestDepartment = departments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (var employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }
        }

    } 
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
    }

    class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }

        public double TotalSalaries { get; set; }

        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
            Employees = new List<Employee>();
        }

        public void AddNewEmployee(string currentEmployeeName, double currentEmployeeSalary)
        {
            this.TotalSalaries += currentEmployeeSalary;
            this.Employees.Add(new Employee(currentEmployeeName, currentEmployeeSalary));
        }
    }
}
