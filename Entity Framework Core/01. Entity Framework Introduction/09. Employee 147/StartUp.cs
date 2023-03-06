using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext dbContext = new SoftUniContext())
            {
                string result = GetEmployee147(dbContext);
                Console.WriteLine(result);
            }
        }

        public static string GetEmployee147(SoftUniContext context)
        {           
            StringBuilder output = new StringBuilder();

            Employee employee = context.Employees
                .First(e => e.EmployeeId == 147);


            var employeeProjects = context.Projects
                .Where(p => p.EmployeesProjects.Any(ep => ep.EmployeeId == employee.EmployeeId))
                .Select(p => new
                {
                    p.Name
                });


            output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var project in employeeProjects.OrderBy(empProject => empProject.Name))
            {
                output.AppendLine(project.Name);
            }

            return output.ToString().TrimEnd();
        }
    }
}
