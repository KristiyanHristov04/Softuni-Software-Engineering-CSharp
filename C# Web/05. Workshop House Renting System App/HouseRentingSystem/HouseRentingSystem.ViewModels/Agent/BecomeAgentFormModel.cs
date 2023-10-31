using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Common.DataConstants.Agent;

namespace HouseRentingSystem.ViewModels.Agent
{
    public class BecomeAgentFormModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
