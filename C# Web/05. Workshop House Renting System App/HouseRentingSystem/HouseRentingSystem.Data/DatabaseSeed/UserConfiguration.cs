using HouseRentingSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static HouseRentingSystem.Common.DataConstants.AdminUser;

namespace HouseRentingSystem.Data.DatabaseSeed
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedUsers());
        }

        private List<ApplicationUser> SeedUsers()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();

            var hasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser AgentUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com",
                FirstName = "Linda",
                LastName = "Michaels"
            };

            AgentUser.PasswordHash =
                            hasher.HashPassword(AgentUser, "agent123");

            ApplicationUser GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Teodor",
                LastName = "Lesly"
            };
            GuestUser.PasswordHash =
                            hasher.HashPassword(AgentUser, "guest123");

            ApplicationUser AdminUser = new ApplicationUser()
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail,
                Email = AdminEmail,
                NormalizedEmail = AdminEmail,
                FirstName = "Great",
                LastName = "Admin"
            };

            AdminUser.PasswordHash =
                            hasher.HashPassword(AdminUser, "admin123");

            users.Add(AgentUser);
            users.Add(GuestUser);
            users.Add(AdminUser);

            return users;
        }
    }
}
