using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Data;
using ProductsAPI.Services.Interfaces;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService _productService)
        {
            this.productService = _productService;
        }

        /// <summary>
        /// Gets a list with all products.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/products
        ///     {   
        ///     }
        /// </remarks>
        /// <response code="200">Returns OK</response>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return this.productService.GetAllProducts();
        }

        /// <summary>
        /// Gets a product by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            if (this.productService.GetProductById(id) == null) 
            {
                return NotFound();
            }

            return this.productService.GetProductById(id);
        }

        /// <summary>
        /// Adds new product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            product = this.productService.CreateProduct(product.Name, product.Description);
            return Ok();
        }


        /// <summary>
        /// Updates product by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (this.productService.GetProductById(id) == null)
            {
                return NotFound();
            }

            this.productService.EditProduct(id, product);

            return NoContent();
        }

        /// <summary>
        /// Updates product by id partially.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchProduct(int id, Product product)
        {
            if (this.productService.GetProductById(id) == null)
            {
                return NotFound();
            }

            this.productService.EditProductPartially(id, product);

            return NoContent();
        }

        /// <summary>
        /// Deletes product by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            if (this.productService.GetProductById(id) == null)
            {
                return NotFound();
            }

            var product = this.productService.DeleteProduct(id);

            return product;
        }
    }
}
