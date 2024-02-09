using Microsoft.EntityFrameworkCore;
using WebApplication2.Data.Models;

namespace WebApplication2.Data
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options)
            : base(options)
        {

        }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatMessage>()
                .Property(x => x.Date)
                .HasDefaultValue(DateTime.Now);

            base.OnModelCreating(modelBuilder);
        }
    }
}
