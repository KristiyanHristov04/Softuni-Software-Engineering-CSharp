using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Data.DatabaseSeed
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }

        private List<Category> SeedCategories()
        {
            List<Category> categories = new List<Category>();

            Category CottageCategory = new Category()
            {
                Id = 1,
                Name = "Cottage"
            };

            Category SingleCategory = new Category()
            {
                Id = 2,
                Name = "Single-Family"
            };

            Category DuplexCategory = new Category()
            {
                Id = 3,
                Name = "Duplex"
            };

            categories.Add(CottageCategory);
            categories.Add(SingleCategory);
            categories.Add(DuplexCategory);

            return categories;
        }
    }
}
