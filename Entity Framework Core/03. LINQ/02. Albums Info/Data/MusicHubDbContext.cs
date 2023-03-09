using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Common;
using MusicHub.Data.Models;

namespace MusicHub.Data
{
    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        { }

        public MusicHubDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
                optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Song

            modelBuilder.Entity<Song>().HasKey(s => s.Id);
            modelBuilder.Entity<Song>().Property(s => s.Name).HasMaxLength(GlobalConstants.SongNameMaxLength);
            
            //Album

            modelBuilder.Entity<Album>().HasKey(a => a.Id);
            modelBuilder.Entity<Album>().Property(a => a.Name).HasMaxLength(GlobalConstants.AlbumNameMaxLength);
            
            //Performer

            modelBuilder.Entity<Performer>().HasKey(p => p.Id);
            
            modelBuilder.Entity<Performer>().Property(p => p.FirstName)
                .HasMaxLength(GlobalConstants.PerformerFirstNameMaxLength);
            
            modelBuilder.Entity<Performer>().Property(p => p.LastName)
                .HasMaxLength(GlobalConstants.PerformerLastNameMaxLength);
            
            //Producer

            modelBuilder.Entity<Producer>().HasKey(p => p.Id);

            modelBuilder.Entity<Producer>().Property(p => p.Name).HasMaxLength(GlobalConstants.ProducerNameMaxLength);
            
            
            
            //SongPerformer

            modelBuilder.Entity<SongPerformer>().HasKey(sp => new { sp.SongId, sp.PerformerId });
            
            //Writer

            modelBuilder.Entity<Writer>().HasKey(w => w.Id);

            modelBuilder.Entity<Writer>().Property(w => w.Name).HasMaxLength(GlobalConstants.WriterNameMaxLength);
            
            //Relations

            modelBuilder.Entity<SongPerformer>()
                .HasOne(sp => sp.Performer)
                .WithMany(p => p.PerformerSongs)
                .HasForeignKey(sp => sp.PerformerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SongPerformer>()
                .HasOne(sp => sp.Song)
                .WithMany(s => s.SongPerformers)
                .HasForeignKey(p => p.SongId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Writer>()
                .HasMany(w => w.Songs)
                .WithOne(s => s.Writer)
                .HasForeignKey(s => s.WriterId);

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.AlbumId);

            modelBuilder.Entity<Producer>()
                .HasMany(p => p.Albums)
                .WithOne(a => a.Producer)
                .HasForeignKey(a => a.ProducerId);
            
            
        }
    }
}