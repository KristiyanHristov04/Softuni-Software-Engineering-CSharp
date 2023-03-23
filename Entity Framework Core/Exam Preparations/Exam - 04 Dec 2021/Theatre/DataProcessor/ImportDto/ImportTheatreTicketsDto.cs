using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreTicketsDto
    {
        [Required]
        [MinLength(GlobalConstants.TheatreNameMinLength)]
        [MaxLength(GlobalConstants.TheatreNameMaxLength)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [Range(GlobalConstants.TheatreNumberOfHallsMin, GlobalConstants.TheatreNumberOfHallsMax)]
        [JsonProperty("NumberOfHalls")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(GlobalConstants.TheatreDirectorMinLength)]
        [MaxLength(GlobalConstants.TheatreDirectorMaxLength)]
        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Tickets")]
        public ImportTicketDto[] Tickets { get; set; }
    }
}
