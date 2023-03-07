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
                string result = GetEmployeesByFirstNameStartingWithSa(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .ToArray();

            foreach (var employee in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return output.ToString().TrimEnd();
        }
    }
}
