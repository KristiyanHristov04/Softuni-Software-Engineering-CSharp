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
                string result = GetEmployeesFromResearchAndDevelopment(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development") //Thanks to the navigational property we are able to do it this way!
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray(); //Materializing

            foreach (var employee in employees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
