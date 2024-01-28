using MyApp.Services;
using MyApp.Services.Interfaces;
using MyApp.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Tests.Unit_Tests
{
    public class ProductServiceTests : BaseTest
    {
        private readonly IProductService productService;
        public ProductServiceTests()
        {
            this.productService = new ProductService(context);
        }

        [Fact]
        public async Task ExistsByIdAsync_ShouldReturnTrue_WithValidData()
        {
            //Arrange

            //Act
            bool result = await this.productService.ExistsByIdAsync(1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ExistsByIdAsync_ShouldReturnFalse_WithValidData()
        {
            //Arrange

            //Act
            bool result = await this.productService.ExistsByIdAsync(4);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task AddProductAsync_ShouldAddNewProduct()
        {
            //Arrange
            ProductFormModel model = new ProductFormModel()
            {
                Name = "Carpet",
                Price = 211.50m
            };

            //Act
            await this.productService.AddProductAsync(model);

            //Assert
            var product = await this.context.Products.FindAsync(4);

            Assert.NotNull(product);
            Assert.Equal(4, this.context.Products.Count());
            Assert.Equal("Carpet", product.Name);
            Assert.Equal(211.50m, product.Price);
        }

        [Fact]
        public async Task AllProductsAsync_ShouldReturnCorrectCount()
        {
            //Arrange
            int productsCount = this.context.Products.Count();

            //Act
            var products = await this.productService.AllProductsAsync();
            int result = products.Count();

            //Assert
            Assert.Equal(productsCount, result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveProduct_WithValidData()
        {
            //Arrange

            //Act
            await this.productService.DeleteAsync(2);

            //Assert
            var product = await this.context.Products.FindAsync(2);
            Assert.Equal(2, this.context.Products.Count());
            Assert.Null(product);
        }

        [Fact]
        public async Task EditAsync_ShouldEditProductSuccessfully()
        {
            //Arrange
            ProductFormModel model = new ProductFormModel()
            {
                Name = "Lamp",
                Price = 52m
            };

            //Act
            await this.productService.EditAsync(1, model);

            //Assert
            var product = await this.context.Products.FindAsync(1);

            Assert.NotNull(product);
            Assert.Equal("Lamp", product.Name);
            Assert.Equal(52m, product.Price);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectProduct()
        {
            //Arrange

            //Act
            var result = await this.productService.GetByIdAsync(1);

            //Assert
            Assert.Equal("Table", result.Name);
            Assert.Equal(20.00m, result.Price);
        }
    }
}
