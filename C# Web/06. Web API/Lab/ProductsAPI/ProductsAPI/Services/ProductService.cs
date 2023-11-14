using ProductsAPI.Data;
using ProductsAPI.Services.Interfaces;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext context;
        public ProductService(ProductDbContext _context)
        {
            this.context = _context;
        }

        public Product CreateProduct(string name, string description)
        {
            Product newProduct = new Product()
            {
                Name = name,
                Description = description
            };

            this.context.Products.Add(newProduct);
            this.context.SaveChanges();

            return newProduct;
        }

        public Product DeleteProduct(int id)
        {
            Product productToBeRemoved = this.context.Products.Find(id);

            this.context.Products.Remove(productToBeRemoved);
            this.context.SaveChanges();

            return productToBeRemoved;
        }

        public void EditProduct(int id, Product product)
        {
            Product productToEdit = this.context.Products.Find(id);

            productToEdit.Name = product.Name;
            productToEdit.Description = product.Description;

            this.context.SaveChanges();
        }

        public void EditProductPartially(int id, Product product)
        {
            Product productPatch = this.context.Products.Find(id);

            productPatch.Name = String.IsNullOrEmpty(product.Name)
                ? productPatch.Name : product.Name;
            productPatch.Description = String.IsNullOrEmpty(product.Description)
                ? productPatch.Description : product.Description;

            this.context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return this.context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return this.context.Products.Find(id);
        }
    }
}
