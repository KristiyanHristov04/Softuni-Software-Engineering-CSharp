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
                string result = DeleteProjectById(dbContext);
                Console.WriteLine(result);
            }
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var projectToDelete = context.Projects
                .Find(2);

            var employeeProjectToBeDeleted = context.EmployeesProjects
                .Where(ep => ep.ProjectId == projectToDelete.ProjectId)
                .ToArray();

            context.EmployeesProjects.RemoveRange(employeeProjectToBeDeleted);

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();


            var projects = context.Projects
                .Take(10);

            foreach (var project in projects)
            {
                output.AppendLine(project.Name);
            }

            return output.ToString().TrimEnd();
        }
    }
}
