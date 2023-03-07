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
                string result = GetLatestProjects(dbContext);
                Console.WriteLine(result);
            }
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                }).OrderBy(p => p.Name)
                .ToArray();

            foreach (var project in projects)
            {
                output.AppendLine(project.Name);
                output.AppendLine(project.Description);
                output.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return output.ToString().TrimEnd();
        }
    }
}
