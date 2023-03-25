using Artillery.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportGunDto
    {
        [Required]
        [JsonProperty("ManufacturerId")]
        public int ManufacturerId { get; set; }

        [Required]
        [Range(GlobalConstants.GunWeightMin, GlobalConstants.GunWeightMax)]
        [JsonProperty("GunWeight")]
        public int GunWeight { get; set; }

        [Required]
        [Range(GlobalConstants.GunBarrelLengthMin, GlobalConstants.GunBarrelLengthMax)]
        [JsonProperty("BarrelLength")]
        public double BarrelLength { get; set; }

        [JsonProperty("NumberBuild")]
        public int? NumberBuild { get; set; }

        [Required]
        [Range(GlobalConstants.GunRangeMin, GlobalConstants.GunRangeMax)]
        [JsonProperty("Range")]
        public int Range { get; set; }

        [Required]
        [JsonProperty("GunType")]
        public string GunType { get; set; }

        [Required]
        [JsonProperty("ShellId")]
        public int ShellId { get; set; }

        [JsonProperty("Countries")]
        public ImportGunsCountryDto[] Countries { get; set; }
    }
}
