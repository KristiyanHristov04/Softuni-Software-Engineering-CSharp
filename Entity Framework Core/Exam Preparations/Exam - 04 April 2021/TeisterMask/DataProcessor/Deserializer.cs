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

                DateTime projectOpenDate;
                bool isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);
                if (!isProjectOpenDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDueDateFinal = null;
                if (!string.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    DateTime projectDueDate;
                    bool isProjectDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDate);
                    if (!isProjectDueDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    projectDueDateFinal = projectDueDate;
                }       

                Project project = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDateFinal
                };

                List<Task> tasks = new List<Task>();
                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);
                    if (!isTaskOpenDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;
                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);
                    if (!isTaskDueDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskDueDate > projectDueDateFinal)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isExecutionTypeValid = Enum.TryParse(typeof(ExecutionType), taskDto.ExecutionType, out object executionType);
                    bool isLabelTypeValid = Enum.TryParse(typeof(LabelType), taskDto.LabelType, out object labelType);

                    Task task = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)executionType,
                        LabelType = (LabelType)labelType
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

                List<EmployeeTask> employeeTasks = new List<EmployeeTask>();
                foreach (var taskDtoId in employeeDto.Tasks.Distinct())
                {
                    if (!context.Tasks.Any(t => t.Id == taskDtoId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        Employee = employee,
                        TaskId = taskDtoId
                    };

                    employeeTasks.Add(employeeTask);
                }
                employee.EmployeesTasks = employeeTasks;
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