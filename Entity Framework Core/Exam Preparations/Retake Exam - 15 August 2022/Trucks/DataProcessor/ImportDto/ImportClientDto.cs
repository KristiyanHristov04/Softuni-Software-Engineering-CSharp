using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Common;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDto
    {
        [Required]
        [MinLength(GlobalConstants.ClientNameMinLength)]
        [MaxLength(GlobalConstants.ClientNameMaxLength)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientNationalityMinLength)]
        [MaxLength(GlobalConstants.ClientNationalityMaxLength)]
        [JsonProperty("Nationality")]
        public string Nationality { get; set; }

        [Required]
        [JsonProperty("Type")]
        public string Type { get; set; }
        public int[] Trucks { get; set; }
    }
}
