using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(GlobalConstants.EmployeeUsernameMinLength)]
        [MaxLength(GlobalConstants.EmployeeUsernameMaxLength)]
        [RegularExpression(GlobalConstants.EmployeeUsernameRegularExpression)]
        [JsonProperty("Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.EmployeePhoneRegularExpression)]
        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Tasks")]
        public int[] Tasks { get; set; }
    }
}
