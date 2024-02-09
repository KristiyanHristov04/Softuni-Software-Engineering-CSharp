using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Data.Models;
using MyApp.Services.Interfaces;
using MyApp.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductsDbContext context;
        public ProductService(ProductsDbContext context)
        {
            this.context = context;
        }

        public async Task AddProductAsync(ProductFormModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
            };

            await this.context.Products.AddAsync(product);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> AllProductsAsync()
        {
            List<ProductViewModel>? products = await this.context.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                })
                .ToListAsync();

            return products;
        }

        public async Task DeleteAsync(int id)
        {
            Product product = await this.context.Products.FindAsync(id);

            this.context.Products.Remove(product);
            await this.context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, ProductFormModel model)
        {
            Product product = this.context.Products.Find(id)!;

            product.Name = model.Name;
            product.Price = model.Price;

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await this.context.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<ProductFormModel> GetByIdAsync(int id)
        {
            Product product = await this.context.Products.FindAsync(id);

            ProductFormModel model = new ProductFormModel()
            {
                Name = product.Name,
                Price = product.Price
            };

            return model;
        }
    }
}
