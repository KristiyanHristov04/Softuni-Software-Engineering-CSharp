using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main()
        {
            using (SoftUniContext dbContext = new SoftUniContext())
            {
                string result = GetEmployeesWithSalaryOver50000(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var employee in employees)
            {
                output.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
