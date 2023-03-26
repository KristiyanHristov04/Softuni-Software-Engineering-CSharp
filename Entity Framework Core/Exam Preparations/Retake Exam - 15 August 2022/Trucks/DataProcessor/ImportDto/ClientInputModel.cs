using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.DataProcessor.ImportDto
{ 
    public class ClientInputModel
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }

        [JsonProperty("Type")]
        [Required]
        public string Type { get; set; }

        [JsonProperty("Trucks")]
        public List<int> Trucks { get; set; }
    }
}
