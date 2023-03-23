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
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [Required]
        [MinLength(GlobalConstants.PlayTitleMinLength)]
        [MaxLength(GlobalConstants.PlayTitleMaxLength)]
        [XmlElement("Title")]
        public string Title { get; set; }

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }

        [Required]
        [Range(GlobalConstants.PlayRatingMin, GlobalConstants.PlayRatingMax)]
        [XmlElement("Raiting")]
        public float Rating { get; set; }

        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayDescriptionMaxLength)]
        [XmlElement("Description")]
        public string Description { get; set; }

        [Required]
        [MinLength(GlobalConstants.PlayScreenWriterMinLength)]
        [MaxLength(GlobalConstants.PlayScreenWriterMaxLength)]
        [XmlElement("Screenwriter")]
        public string Screenwriter { get; set; }
    }
}
