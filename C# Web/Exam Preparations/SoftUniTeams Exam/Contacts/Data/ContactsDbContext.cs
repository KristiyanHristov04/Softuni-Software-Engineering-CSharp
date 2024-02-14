using Contacts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Contacts.Common.DataConstants.AplicationUser;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext<ApplicationUser>
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ApplicationUserContact> ApplicationUserContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUserContact>()
                .HasKey(auc => new { auc.ApplicationUserId, auc.ContactId });

            builder.Entity<ApplicationUser>()
                .Property(au => au.UserName)
                .IsRequired(true)
                .HasMaxLength(UsernameMaxLength);

            builder.Entity<ApplicationUser>()
               .Property(au => au.Email)
               .HasMaxLength(EmailMaxLength)
               .IsRequired(true);

            builder
              .Entity<Contact>()
              .HasData(new Contact()
              {
                  Id = 1,
                  FirstName = "Bruce",
                  LastName = "Wayne",
                  PhoneNumber = "+359881223344",
                  Address = "Gotham City",
                  Email = "imbatman@batman.com",
                  Website = "www.batman.com"
              });

            
        }
    }
}