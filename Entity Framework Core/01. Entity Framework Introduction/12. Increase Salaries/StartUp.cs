using SoftUni.Data;
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
                string result = IncreaseSalaries(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                e.Department.Name == "Tool Design" ||
                e.Department.Name == "Marketing" ||
                e.Department.Name == "Information Services")
                .ToArray();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            foreach (var employee in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return output.ToString().TrimEnd();
        }
    }
}
