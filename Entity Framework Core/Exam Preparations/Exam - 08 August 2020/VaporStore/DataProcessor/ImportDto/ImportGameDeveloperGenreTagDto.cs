using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaporStore.Common;

namespace VaporStore.DataProcessor.ImportDto
{
    public class ImportGameDeveloperGenreTagDto
    {
        [Required]
        [JsonProperty("Name")]
        public string GameName { get; set; }

        [Required]
        [Range(typeof(decimal), GlobalConstants.GamePriceMinValue, GlobalConstants.GamePriceMaxValue)]
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }

        [Required]
        [JsonProperty("Developer")]
        public string DeveloperName { get; set; }

        [Required]
        [JsonProperty("Genre")]
        public string GenreName { get; set; }

        [JsonProperty("Tags")]
        public string[] TagNames { get; set; }
    }
}
