using MyApp.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> AllProductsAsync();

        Task AddProductAsync(ProductFormModel model);

        Task<ProductFormModel> GetByIdAsync(int id);

        Task EditAsync(int id, ProductFormModel model);

        Task DeleteAsync(int id);

        Task<bool> ExistsByIdAsync(int id);
    }
}
