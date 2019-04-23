using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using DMD.Test.Models;
using DMD.Test.Models.Models;
using DMD.Test.Server.Controllers;
using DMD.Test.Services;

namespace DMD.Test.Server.UnitTests.Controllers
{
    public class AssetControllerTests
    {
        [Fact]
        public async void Get_ReturnsAllProducts_WhenCategoryIsEmpty()
        {
            var context = new FakeContext();

            // Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(service => service.Get())
                .ReturnsAsync(context.Products);

            var controller = new ProductController(mockService.Object);

            // Act
            var res = await controller.Get(string.Empty);

            // Assert
            Assert.Equal(context.Products.Count(), res.Count());
            Assert.IsAssignableFrom<IEnumerable<Product>>(res);
        }

        [Fact]
        public async void Get_ReturnsAllProducts_WhenCategoryIsNoneEmpty()
        {
            var context = new FakeContext();

            // Arrange
            var type = "Savings";
            var mockService = new Mock<IProductService>();
            mockService.Setup(service => service.Get(type))
                .ReturnsAsync(context.Products.Where(a => a.Category.Name == type));

            var controller = new ProductController(mockService.Object);

            // Act
            var res = await controller.Get(type);

            // Assert
            Assert.Equal(context.Products.Count(a => a.Category.Name == type), res.Count());
            Assert.IsAssignableFrom<IEnumerable<Product>>(res);
        }

        [Fact]
        public async void Get_ReturnsAllCategories_WhenTypeIsNoneExists()
        {
            var context = new FakeContext();

            // Arrange
            var type = "Non exists type";
            var mockService = new Mock<IProductService>();
            mockService.Setup(service => service.Get(type))
                .ReturnsAsync(context.Products.Where(a => a.Category.Name == type));

            var controller = new ProductController(mockService.Object);

            // Act
            var res = await controller.Get(type);

            // Assert
            Assert.Empty(res);
            Assert.IsAssignableFrom<IEnumerable<Product>>(res);
        }

        [Fact]
        public async void Get_ReturnsAllCategories()
        {
            var context = new FakeContext();

            // Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(service => service.GetTypes())
                .ReturnsAsync(context.Categories);

            var controller = new ProductController(mockService.Object);

            // Act
            var res = await controller.GetTypes();

            // Assert
            Assert.Equal(context.Categories.Count(), res.Count());
            Assert.IsAssignableFrom<IEnumerable<Category>>(res);
        }
    }
}
