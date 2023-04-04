// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), xmlRoot);

            StringBuilder output = new StringBuilder();
            using StringReader reader = new StringReader(xmlString);

            ImportProjectDto[] projectDtos = (ImportProjectDto[])xmlSerializer.Deserialize(reader);
            List<Project> projects = new List<Project>();

            foreach (var projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDateProject;
                bool isOpenDateProjectValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDateProject);
                if (!isOpenDateProjectValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDateProject;
                if (string.IsNullOrEmpty(projectDto.DueDate))
                {
                    dueDateProject = null;
                }
                else
                {
                    DateTime dueDateProjectTemp;
                    bool isDueDateProjectValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateProjectTemp);
                    if (!isDueDateProjectValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    dueDateProject = dueDateProjectTemp;
                }

                Project project = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = openDateProject,
                    DueDate = dueDateProject
                };

                List<Task> tasks = new List<Task>();
                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime openDateTask;
                    bool isOpenDateTaskValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDateTask);
                    if (!isOpenDateTaskValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime dueDateTask;
                    bool isDueDateTaskValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateTask);
                    if (!isDueDateTaskValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (openDateTask < openDateProject || dueDateTask > dueDateProject)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = openDateTask,
                        DueDate = dueDateTask,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    tasks.Add(task);
                }
                project.Tasks = tasks;
                projects.Add(project);
                output.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ImportEmployeeDto[] employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);
            List<Employee> employees = new List<Employee>();

            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                List<EmployeeTask> employeesTasks = new List<EmployeeTask>();
                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    Task task = context.Tasks.FirstOrDefault(t => t.Id == taskId);
                    if (task == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        Employee = employee,
                        Task = task
                    };

                    employeesTasks.Add(employeeTask);
                }
                employee.EmployeesTasks = employeesTasks;
                employees.Add(employee);
                output.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}