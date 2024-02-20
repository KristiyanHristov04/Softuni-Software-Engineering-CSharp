using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data.Models;

namespace SeminarHub.Data
{
    public class SeminarHubDbContext : IdentityDbContext
    {
        public SeminarHubDbContext(DbContextOptions<SeminarHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Seminar> Seminars { get; set; }
        public DbSet<SeminarParticipant> SeminarsParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Seminar>()
                .HasMany(s => s.SeminarsParticipants)
                .WithOne(sp => sp.Seminar)
                .HasForeignKey(sp => sp.SeminarId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SeminarParticipant>()
                .HasKey(sp => new { sp.SeminarId, sp.ParticipantId });

            builder
               .Entity<Category>()
               .HasData(new Category()
               {
                   Id = 1,
                   Name = "Technology & Innovation"
               },
               new Category()
               {
                   Id = 2,
                   Name = "Business & Entrepreneurship"
               },
               new Category()
               {
                   Id = 3,
                   Name = "Science & Research"
               },
               new Category()
               {
                   Id = 4,
                   Name = "Arts & Culture"
               });

            base.OnModelCreating(builder);
        }
    }
}