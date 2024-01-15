using HouseRentingSystem.Data.DatabaseSeed;
using HouseRentingSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Data
{
    public class HouseRentingDbContext : IdentityDbContext<ApplicationUser>
    {
        private bool shouldSeed;
        public HouseRentingDbContext(DbContextOptions<HouseRentingDbContext> options, bool seed = true)
            : base(options)
        {
            if (!Database.IsRelational())
            {
                Database.EnsureCreated();
            }

            shouldSeed = seed;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Agent> Agents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<House>()
                .HasOne(h => h.Category)
                .WithMany(c => c.Houses)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<House>()
                .HasOne(h => h.Agent)
                .WithMany(h => h.Houses)
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<House>()
                .Property(h => h.PricePerMonth)
                .HasColumnType("decimal(18, 2)");

            if (shouldSeed)
            {
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new AgentConfiguration());
                builder.ApplyConfiguration(new CategoryConfiguration());
                builder.ApplyConfiguration(new HouseConfiguration());
            }

            base.OnModelCreating(builder);
        }
    }
}