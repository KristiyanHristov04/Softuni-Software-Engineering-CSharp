using ProductsAPI.Data;

namespace ProductsAPI.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        Product CreateProduct(string name, string description);
        void EditProduct(int id, Product product);
        void EditProductPartially(int id, Product product);
        Product DeleteProduct(int id);
    }
}
