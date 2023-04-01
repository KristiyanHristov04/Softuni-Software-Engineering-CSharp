using Boardgames.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDto
    {
        [Required]
        [MinLength(GlobalConstants.SellerNameMinLength)]
        [MaxLength(GlobalConstants.SellerNameMaxLength)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.SellerAddressMinLength)]
        [MaxLength(GlobalConstants.SellerAddressMaxLength)]
        [JsonProperty("Address")]
        public string Address { get; set; }

        [Required]
        [JsonProperty("Country")]
        public string Country { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.SellerWebsiteRegularExpression)]
        [JsonProperty("Website")]
        public string Website { get; set; }

        [JsonProperty("Boardgames")]
        public int[] Boardgames { get; set; }
    }
}
