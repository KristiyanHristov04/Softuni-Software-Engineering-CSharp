using Footballers.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [RegularExpression(GlobalConstants.TeamNameRegularExpression)]
        [MinLength(GlobalConstants.TeamNameMinLength)]
        [MaxLength(GlobalConstants.TeamNameMaxLength)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.TeamNationalityMinLength)]
        [MaxLength(GlobalConstants.TeamNationalityMaxLength)]
        [JsonProperty("Nationality")]
        public string Nationality { get; set; }

        [Required]
        [JsonProperty("Trophies")]
        public int Trophies { get; set; }
        public int[] Footballers { get; set; }
    }
}
