using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Data.Seed
{
    internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(SeedProducts());
        }

        private List<Product> SeedProducts()
        {
            Product product01 = new Product()
            {
                Id = 1,
                Name = "Table",
                Price = 20.00m
            };

            Product product02 = new Product()
            {
                Id = 2,
                Name = "Chair",
                Price = 15.00m
            };

            Product product03 = new Product()
            {
                Id = 3,
                Name = "TV",
                Price = 275.00m
            };

            return new List<Product> { product01, product02, product03 };
        }
    }
}
