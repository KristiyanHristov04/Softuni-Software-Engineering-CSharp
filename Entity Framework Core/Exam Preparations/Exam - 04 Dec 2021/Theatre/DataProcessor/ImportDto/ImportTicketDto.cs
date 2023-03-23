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
    public class ImportTicketDto
    {
        [Required]
        [Range(typeof(decimal), GlobalConstants.TicketPriceMin, GlobalConstants.TicketPriceMax)]
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [Required]
        [Range(GlobalConstants.TicketRowNumberMin, GlobalConstants.TicketRowNumberMax)]
        [JsonProperty("RowNumber")]
        public sbyte RowNumber { get; set; }

        [Required]
        [JsonProperty("PlayId")]
        public int PlayId { get; set; }
    }
}
