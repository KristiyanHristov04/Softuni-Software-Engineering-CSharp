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
    [XmlType("Shell")]
    public class ImportShellDto
    {
        [Required]
        [Range(GlobalConstants.ShellWeightMin, GlobalConstants.ShellWeightMax)]
        [XmlElement("ShellWeight")]
        public double ShellWeight { get; set; }

        [Required]
        [MinLength(GlobalConstants.ShellCaliberMinLength)]
        [MaxLength(GlobalConstants.ShellCaliberMaxLength)]
        [XmlElement("Caliber")]
        public string Caliber { get; set; }
    }
}
