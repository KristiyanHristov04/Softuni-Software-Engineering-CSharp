using Artillery.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountryDto
    {
        [Required]
        [MinLength(GlobalConstants.CountryNameMinLength)]
        [MaxLength(GlobalConstants.CountryNameMaxLength)]
        [XmlElement("CountryName")]
        public string CountryName { get; set; }

        [Required]
        [Range(GlobalConstants.CountryArmySizeMinSize, GlobalConstants.CountryArmySizeMaxSize)]
        [XmlElement("ArmySize")]
        public int ArmySize { get; set; }
    }
}
