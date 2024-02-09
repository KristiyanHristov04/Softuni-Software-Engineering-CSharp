using Microsoft.AspNetCore.Mvc;
using MyApp.Services.Interfaces;
using MyApp.ViewModels.Product;

namespace MyApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(
            IProductService productService
            )
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await this.productService.AllProductsAsync();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ProductFormModel model = new ProductFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.productService.AddProductAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.productService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            ProductFormModel product = await this.productService.GetByIdAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductFormModel model)
        {
            await this.productService.EditAsync(id, model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.productService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            ProductFormModel product = await this.productService.GetByIdAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, ProductFormModel model)
        {
            if (await this.productService.ExistsByIdAsync(id))
            {
                await this.productService.DeleteAsync(id);
            }
            else
            {
                return BadRequest();
            }
             
            return RedirectToAction(nameof(All));
        }
    }
}
