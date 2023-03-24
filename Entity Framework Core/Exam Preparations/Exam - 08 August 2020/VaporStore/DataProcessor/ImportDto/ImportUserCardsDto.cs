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
    public class ImportUserCardsDto
    {
        [Required]
        [RegularExpression(GlobalConstants.UserFullNameRegularExpression)]
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [Required]
        [MinLength(GlobalConstants.UserUsernameMinLength)]
        [MaxLength(GlobalConstants.UserUsernameMaxLength)]
        [JsonProperty("Username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [Required]
        [Range(GlobalConstants.UserAgeMinValue, GlobalConstants.UserAgeMaxValue)]
        [JsonProperty("Age")]
        public int Age { get; set; }

        public ImportCardDto[] Cards { get; set; }
    }
}
