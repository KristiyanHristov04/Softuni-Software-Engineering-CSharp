namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Countries");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCountryDto[]), xmlRoot);

            StringBuilder output = new StringBuilder();
            using StringReader reader = new StringReader(xmlString);

            ImportCountryDto[] countryDtos = (ImportCountryDto[])xmlSerializer.Deserialize(reader);
            List<Country> countries = new List<Country>();

            foreach (var countryDto in countryDtos)
            {
                if (!IsValid(countryDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize
                };

                countries.Add(country);
                output.AppendLine(String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Manufacturers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportManufacturerDto[]), xmlRoot);

            StringBuilder output = new StringBuilder();
            using StringReader reader = new StringReader(xmlString);

            ImportManufacturerDto[] manufacturerDtos = (ImportManufacturerDto[])xmlSerializer.Deserialize(reader);
            List<Manufacturer> manufacturers = new List<Manufacturer>();

            foreach (var manufacturerDto in manufacturerDtos)
            {
                if (!IsValid(manufacturerDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer()
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                };

                if (manufacturers.Any(m => m.ManufacturerName == manufacturer.ManufacturerName))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                string[] manufacturerInfo = manufacturer.Founded.Split(", ").TakeLast(2).ToArray();

                manufacturers.Add(manufacturer);
                output.AppendLine(String.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, string.Join(", ", manufacturerInfo)));
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Shells");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportShellDto[]), xmlRoot);

            StringBuilder output = new StringBuilder();
            using StringReader reader = new StringReader(xmlString);

            ImportShellDto[] shellDtos = (ImportShellDto[])xmlSerializer.Deserialize(reader);
            List<Shell> shells = new List<Shell>();

            foreach (var shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber
                };

                shells.Add(shell);
                output.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            ImportGunDto[] gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);
            StringBuilder output = new StringBuilder();
            List<Gun> guns = new List<Gun>();

            foreach (var gunDto in gunDtos)
            {
                if (!IsValid(gunDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                GunType gunType;
                bool isValidGunType = Enum.TryParse(typeof(GunType), gunDto.GunType, out object gunTypeValue);
                if (!isValidGunType)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                gunType = (GunType)gunTypeValue;

                Gun gun = new Gun()
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = gunType,
                    ShellId = gunDto.ShellId
                };

                List<CountryGun> countriesGuns = new List<CountryGun>();
                foreach (var countryId in gunDto.Countries)
                {
                    CountryGun countryGun = new CountryGun()
                    {
                        Gun = gun,
                        CountryId = countryId.Id
                    };

                    countriesGuns.Add(countryGun);
                }

                foreach (var realCountryGun in countriesGuns)
                {
                    gun.CountriesGuns.Add(realCountryGun);
                }

                guns.Add(gun);
                output.AppendLine(String.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(guns);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}