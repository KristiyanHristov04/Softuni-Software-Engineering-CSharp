using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftJail.DataProcessor.ImportDto
{
    public class CellDto
    {
        [Required]
        [Range(1, 1000)]
        [JsonProperty("CellNumber")]
        public int CellNumber { get; set; }

        [Required]
        [JsonProperty("HasWindow")]
        public bool HasWindow { get; set; }
    }
}
