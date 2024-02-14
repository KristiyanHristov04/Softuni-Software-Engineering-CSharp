using System.ComponentModel.DataAnnotations;
using static Contacts.Common.DataConstants.Contact;
namespace Contacts.ViewModels
{
    public class ContactFormModel
    {
        public int ContactId { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [RegularExpression(PhoneNumberRegexPattern)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }

        [Required]
        [RegularExpression(WebsiteRegexPattern)]
        public string Website { get; set; } = null!;
    }
}
