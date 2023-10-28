using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Data.DatabaseSeed
{
    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(SeedUsers());
        }

        private List<IdentityUser> SeedUsers()
        {
            List<IdentityUser> users = new List<IdentityUser>();

            var hasher = new PasswordHasher<IdentityUser>();

            IdentityUser AgentUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };

            AgentUser.PasswordHash =
                            hasher.HashPassword(AgentUser, "agent123");

            IdentityUser GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };
            GuestUser.PasswordHash =
                            hasher.HashPassword(AgentUser, "guest123");

            users.Add(AgentUser);
            users.Add(GuestUser);

            return users;
        }
    }
}
