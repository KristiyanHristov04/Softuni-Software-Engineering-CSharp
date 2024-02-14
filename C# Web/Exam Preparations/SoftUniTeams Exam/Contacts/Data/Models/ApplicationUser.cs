using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Contacts.Common.DataConstants.AplicationUser;

namespace Contacts.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
            = new List<ApplicationUserContact>();
    }
}
