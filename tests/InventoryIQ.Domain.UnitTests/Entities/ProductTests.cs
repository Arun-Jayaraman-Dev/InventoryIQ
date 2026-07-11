using FluentAssertions;
using InventoryIQ.Domain.Entities;
using InventoryIQ.Domain.Exceptions.Product;

namespace InventoryIQ.Domain.UnitTests.Entities
{
    public class ProductTests
    {
        private static Product CreateValidProduct()
        {
            return new Product("LAPTOP", "LAPTOP-GRAY", 1000m, 5);
        }
        [Fact]
        public void CreateProduct_WithValidData_ShouldCreateProduct()
        {
            // Arrange
            var name = "LAPTOP";
            var sku = "LAPTOP-GRAY";
            var price = 1000m;
            var quantity = 5;

            // Act
            var product = CreateValidProduct();

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

        [Fact]
        public void Decreasestock_WithValidQuantity_ShouldDecreaseStock()
        {
            // Arrange
            var product = new Product("Laptop", "LAP001", 1000m, 10);
            var decreaseQuantity = 5;
            // Act
            product.DecreaseStock(decreaseQuantity);
            // Assert
            product.Quantity.Should().Be(5);
        }

        [Fact]
        public void DecreaseStock_WithQuantityGreaterThanAvailable_ShouldThrowInsufficientStockException()
        {
            // Arrange
            var product = new Product("Laptop", "LAP001", 1000m, 10);
            var decreaseQuantity = 15;

            // Act
            Action act = () => product.DecreaseStock(decreaseQuantity);

            // Assert
            act.Should().Throw<InsufficientStockException>();
        }

        [Fact]
        public void DecreaseStock_WithNegativeQuantity_ShouldThrowInvalidProductQuantityException()
        {
            // Arrange
            var product = new Product("Laptop", "LAP001", 1000m, 10);
            var decreaseQuantity = -5;
            // Act
            Action act = () => product.DecreaseStock(decreaseQuantity);
            // Assert
            act.Should().Throw<InvalidProductQuantityException>();
        }

        [Fact]
        public void IncreaseStock_WithValidQuantity_ShouldIncreaseStock()
        {
            // Arrange
            var product = new Product("Laptop", "LAP001", 1000m, 10);
            var increaseQuantity = 5;
            // Act
            product.IncreaseStock(increaseQuantity);
            // Assert
            product.Quantity.Should().Be(15);
        }

        [Fact]
        public void IncreaseStock_WithNegativeQuantity_ShouldThrowInvalidProductQuantityException()
        {
            // Arrange
            var product = new Product("Laptop", "LAP001", 1000m, 10);
            var increaseQuantity = -5;
            // Act
            Action act = () => product.IncreaseStock(increaseQuantity);
            // Assert
            act.Should().Throw<InvalidProductQuantityException>();
        }

        [Fact]
        public void RenameProduct_WithValidName_ShouldRenameProduct()
        {
            // Arrange
            var product = CreateValidProduct();
            var newName = "Gaming Laptop";
            // Act
            product.Rename(newName);
            // Assert
            product.Name.Should().Be(newName);
        }

        [Fact]
        public void RenameProduct_WithEmptyName_ShouldThrowInvalidProductNameException()
        {
            // Arrange
            var product = CreateValidProduct();
            var newName = "";
            // Act
            Action act = () => product.Rename(newName);
            // Assert
            act.Should().Throw<InvalidProductNameException>();
        }

        [Fact]
        public void ChangePrice_WithValidPrice_ShouldChangePrice()
        {
            // Arrange
            var product = CreateValidProduct();
            var newPrice = 1200m;
            // Act
            product.ChangePrice(newPrice);
            // Assert
            product.Price.Should().Be(newPrice);
        }

        [Fact]
        public void ChangePrice_WithNegativePrice_ShouldThrowInvalidProductPriceException()
        {
            // Arrange
            var product = CreateValidProduct();
            var newPrice = -1200m;
            // Act
            Action act = () => product.ChangePrice(newPrice);
            // Assert
            act.Should().Throw<InvalidProductPriceException>();
        }
    }
}