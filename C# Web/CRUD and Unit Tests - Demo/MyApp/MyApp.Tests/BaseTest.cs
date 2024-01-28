using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Tests
{
    public class BaseTest : IDisposable
    {
        protected readonly ProductsDbContext context;
        public BaseTest()
        {
            var options = new DbContextOptionsBuilder<ProductsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            this.context = new ProductsDbContext(options);
            SeedProducts();
        }

        private void SeedProducts()
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

            this.context.Products.Add(product01);
            this.context.Products.Add(product02);
            this.context.Products.Add(product03);
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
