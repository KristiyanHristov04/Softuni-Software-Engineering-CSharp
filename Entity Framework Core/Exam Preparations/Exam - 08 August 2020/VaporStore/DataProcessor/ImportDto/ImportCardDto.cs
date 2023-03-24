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
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(GlobalConstants.CardNumberRegularExpression)]
        [JsonProperty("Number")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CardCvcRegularExpression)]
        [JsonProperty("CVC")]
        public string Cvc { get; set; }

        [Required]
        [JsonProperty("Type")]
        public string Type { get; set; }
    }
}
