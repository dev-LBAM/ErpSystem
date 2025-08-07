using Xunit;
using Moq;
using ErpSystem.Domain.Product;
using System.Threading.Tasks;
using System;
using ErpSystem.Application.Services;

namespace ErpSystem.Application.Tests.Features
{
    public class ProductServiceTests
    {
        public class when_creating_a_valid_product
        {
            [Fact]
            public async Task should_call_repository_addasync_once()
            {
                // Arrange
                var mockProductRepository = new Mock<IProductRepository>();
                var productService = new ProductService(mockProductRepository.Object);
                var product = new Product(
                    sku: "PROD-SKU-001",
                    name: "Product Test",
                    description: "Description test",
                    price: 1500m,
                    brandId: Guid.NewGuid(),
                    categoryId: Guid.NewGuid()
                );

                // Act
                await productService.Create(product);

                // Assert
                mockProductRepository.Verify(repo =>
                    repo.AddAsync(It.Is<Product>(p =>
                        p.Id != Guid.Empty &&
                        p.BrandId == product.BrandId &&
                        p.CategoryId == product.CategoryId)),
                    Times.Once);
            }
        }

        public class when_creating_a_null_product
        {
            [Fact]
            public async Task should_throw_argument_null_exception()
            {
                // Arrange
                var mockProductRepository = new Mock<IProductRepository>();
                var productService = new ProductService(mockProductRepository.Object);

                // Act & Assert
                await Assert.ThrowsAsync<ArgumentNullException>(() => productService.Create(null));
            }
        }

        public class when_repository_addasync_fails
        {
            [Fact]
            public async Task should_rethrow_the_exception()
            {
                // Arrange
                var mockProductRepository = new Mock<IProductRepository>();
                var productService = new ProductService(mockProductRepository.Object);
                var product = new Product(
                     sku: "PROD-SKU-001",
                     name: "Product Test",
                     description: "Description test",
                     price: 1500m,
                     brandId: Guid.NewGuid(),
                     categoryId: Guid.NewGuid()
                 );

                // Configure the mock to throw an exception
                mockProductRepository.Setup(repo => repo.AddAsync(It.IsAny<Product>()))
                    .ThrowsAsync(new InvalidOperationException("Database error."));

                // Act & Assert
                await Assert.ThrowsAsync<InvalidOperationException>(() => productService.Create(product));
            }
        }
    }
}