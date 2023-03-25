﻿namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
    {
        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cell> Cells { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
        public DbSet<Prisoner> Prisoners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OfficerPrisoner>(entity =>
            {
                entity.HasKey(e => new { e.OfficerId, e.PrisonerId });

                entity
                    .HasOne<Prisoner>(p => p.Prisoner)
                    .WithMany(p => p.PrisonerOfficers)
                    .HasForeignKey(p => p.PrisonerId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasOne<Officer>(o => o.Officer)
                    .WithMany(o => o.OfficerPrisoners)
                    .HasForeignKey(o => o.OfficerId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}