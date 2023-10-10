using ForumApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; init; }

        private Post FirstPost { get; set; }
        private Post SecondPost { get; set; }
        private Post ThirdPost { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData();

            modelBuilder.Entity<Post>()
                .HasData(FirstPost, SecondPost, ThirdPost);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData()
        {
            this.FirstPost = new Post()
            {
                Id = 1,
                Title = "My First Post",
                Content = "My first post will be about performing " +
                "CRUD operations in MVC. It's so much fun!"
            };

            this.SecondPost = new Post()
            {
                Id = 2,
                Title = "My Second Post",
                Content = "This is my second post. " +
                "CRUD operations in MVC are getting more interesting!"
            };

            this.ThirdPost = new Post()
            {
                Id = 3,
                Title = "My Third Post",
                Content = "Hello There! I'm getting better and better with the " +
                "CRUD operations in MVC. Stay tuned!"
            };
        }
    }
}
