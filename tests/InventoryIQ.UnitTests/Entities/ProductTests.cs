using FluentAssertions;
using InventoryIQ.Domain.Entities;
using InventoryIQ.Domain.Exceptions.Product;

namespace InventoryIQ.Domain.UnitTests.Entities
{
    public class ProductTests
    {
        [Fact]
        public void CreateProduct_WithValidData_ShouldCreateProduct()
        {
            // Arrange
            var name = "Laptop";
            var sku = "LAP001";
            var price = 1000m;
            var quantity = 10;

            // Act
            var product = new Product(name, sku, price, quantity);

            // Assert
            product.Id.Should().NotBe(Guid.Empty);

            product.Name.Should().Be(name);

            product.Sku.Should().Be(sku);

            product.Price.Should().Be(price);

            product.Quantity.Should().Be(quantity);
        }

        [Fact]
        public void CreateProduct_WithEmptyName_ShouldThrowInvalidProductNameException()
        {
            // Arrange
            var sku = "LAP001";
            var price = 1000m;
            var quantity = 10;

            // Act
            Action act = () => new Product("", sku, price, quantity);

            // Assert
            act.Should().Throw<InvalidProductNameException>();
        }

        [Fact]
        public void CreateProduct_WithEmptySku_ShouldThrowInvalidProductSkuException()
        {
            // Arrange
            var name = "Laptop";
            var price = 1000m;
            var quantity = 10;

            // Act
            Action act = () => new Product(name, "", price, quantity);

            // Assert
            act.Should().Throw<InvalidProductSkuException>();
        }

        [Fact]
        public void CreateProduct_WithNegativePrice_ShouldThrowInvalidProductPriceException()
        {
            // Arrange
            var name = "Laptop";
            var sku = "LAP001";
            var quantity = 10;

            // Act
            Action act = () => new Product(name, sku, -1000m, quantity);

            // Assert
            act.Should().Throw<InvalidProductPriceException>();
        }

        [Fact]
        public void CreateProduct_WithNegativeQuantity_ShouldThrowInvalidProductQuantityException()
        {
            // Arrange
            var name = "Laptop";
            var sku = "LAP001";
            var price = 1000m;

            // Act
            Action act = () => new Product(name, sku, price, -10);

            // Assert
            act.Should().Throw<InvalidProductQuantityException>();
        }
    }
}