using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastDto
    {
        [Required]
        [MinLength(GlobalConstants.CastFullNameMinLength)]
        [MaxLength(GlobalConstants.CastFullNameMaxLength)]
        [XmlElement("FullName")]
        public string FullName { get; set; }

        [Required]
        [XmlElement("IsMainCharacter")]
        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CastPhoneNumberRegulaxExpression)]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}
