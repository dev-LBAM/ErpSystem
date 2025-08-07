using Xunit;
using System;
using ErpSystem.Domain.Product;
using ProductEntity = ErpSystem.Domain.Product.Product;

namespace ErpSystem.Domain.Tests.Product
{
    public class ProductTests
    {
        [Theory]
        [InlineData(null, "PROD-SKU-001", "Description")]
        [InlineData("", "PROD-SKU-001", "Description")]
        [InlineData(" ", "PROD-SKU-001", "Description")]

        [InlineData("Valid Name", null, "Description")]
        [InlineData("Valid Name", "", "Description")]
        [InlineData("Valid Name", " ", "Description")]

        [InlineData("Valid Name", "PROD-SKU-001", null)]
        [InlineData("Valid Name", "PROD-SKU-001", "")]   
        [InlineData("Valid Name", "PROD-SKU-001", " ")]
        public void Product_Constructor_ShouldThrowException_WhenRequiredStringIsInvalid(
            string name, string sku, string description)
        {
            Assert.Throws<ArgumentException>(() => new ProductEntity(
                sku: sku,
                name: name,
                description: description,
                price: 50m,
                brandId: Guid.NewGuid(),
                categoryId: Guid.NewGuid()
            ));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Product_Constructor_ShouldThrowException_WhenPriceIsLessOrEqualThanZero(decimal invalidPrice)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ProductEntity(
                sku: "PROD-SKU-001",
                name: "Product Test",
                description: "Description test",
                price: (decimal)invalidPrice,
                brandId: Guid.NewGuid(),
                categoryId: Guid.NewGuid()
            ));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Product_Constructor_ShouldThrowException_WhenUpdatePriceIsLessOrEqualThanZero(decimal invalidPrice)
        {
            var product = new ProductEntity(
                sku: "PROD-SKU-001",
                name: "Product Test",
                description: "Description test",
                price: 50m,
                brandId: Guid.NewGuid(),
                categoryId: Guid.NewGuid()
            );
            Assert.Throws<ArgumentOutOfRangeException>(() => product.UpdatePrice((decimal)invalidPrice));
        }
    }
}