using System.ComponentModel.DataAnnotations;
using static Contacts.Common.DataConstants.Contact;
namespace Contacts.Data.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [RegularExpression(PhoneNumberRegexPattern)]
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }

        [Required]
        [RegularExpression(WebsiteRegexPattern)]
        public string Website { get; set; } = null!;

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; } 
            = new List<ApplicationUserContact>();
    }
}
