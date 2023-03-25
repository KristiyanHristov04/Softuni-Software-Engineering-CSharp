using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerMailsDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"The [A-Z]{1}[a-zA-Z]{0,}")]
        [JsonProperty("Nickname")]
        public string Nickname { get; set; }

        [Required]
        [Range(18, 65)]
        [JsonProperty("Age")]
        public int Age { get; set; }

        [Required]
        [JsonProperty("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [JsonProperty("ReleaseDate")]
        public string? ReleaseDate { get; set; }

        [Range(typeof(decimal), "0.0", "79228162514264337593543950335")]
        [JsonProperty("Bail")]
        public decimal? Bail { get; set; }

        [JsonProperty("CellId")]
        public int? CellId { get; set; }

        public MailDto[] Mails { get; set; }
    }
}
