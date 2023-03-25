namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            DepartmentCellsDto[] departmentCellsDtos = JsonConvert.DeserializeObject<DepartmentCellsDto[]>(jsonString);
            List<Department> departments = new List<Department>();

            StringBuilder output = new StringBuilder();
            foreach (var departmentCellDto in departmentCellsDtos)
            {
                if (!IsValid(departmentCellDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentCellDto.Name
                };

                List<Cell> cells = new List<Cell>();
                bool isDepartmentValid = true;
                foreach (var cellDto in departmentCellDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        isDepartmentValid = false;
                        break;
                    }

                    Cell cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };

                    cells.Add(cell);
                }

                department.Cells = cells;

                if (isDepartmentValid && department.Cells.Count() > 0)
                {
                    departments.Add(department);
                    output.AppendLine(String.Format(SuccessfullyImportedDepartment, department.Name, department.Cells.Count));
                }
                else
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            PrisonerMailsDto[] prisonerDtos = JsonConvert.DeserializeObject<PrisonerMailsDto[]>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (PrisonerMailsDto prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;
                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? releaseDate = null;
                if (!String.IsNullOrEmpty(prisonerDto.ReleaseDate))
                {
                    DateTime releaseDateValue;
                    bool isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                Prisoner p = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                bool areMailsValid = true;
                foreach (MailDto mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        areMailsValid = false;
                        continue;
                    }

                    p.Mails.Add(new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    });
                }

                if (!areMailsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                prisoners.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedPrisoner, p.FullName, p.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            List<Officer> officers = new List<Officer>();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportOfficerDto[] officerDtos = (ImportOfficerDto[])xmlSerializer.Deserialize(stringReader);

                foreach (ImportOfficerDto officerDto in officerDtos)
                {
                    if (!IsValid(officerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object positionObj;
                    bool isPositionValid = Enum.TryParse(typeof(Position), officerDto.Position, out positionObj);

                    if (!isPositionValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object weaponObj;
                    bool isWeaponValid = Enum.TryParse(typeof(Weapon), officerDto.Weapon, out weaponObj);

                    if (!isWeaponValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Officer o = new Officer()
                    {
                        FullName = officerDto.FullName,
                        Salary = officerDto.Salary,
                        Position = (Position)positionObj,
                        Weapon = (Weapon)weaponObj,
                        DepartmentId = officerDto.DepartmentId
                    };

                    foreach (ImportOfficerPrisonerDto prisonerDto in officerDto.Prisoners)
                    {
                        o.OfficerPrisoners.Add(new OfficerPrisoner()
                        {
                            Officer = o,
                            PrisonerId = prisonerDto.PrisonerId
                        });
                    }

                    officers.Add(o);
                    sb.AppendLine(String.Format(SuccessfullyImportedOfficer, o.FullName, o.OfficerPrisoners.Count));
                }

                context.Officers.AddRange(officers);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}