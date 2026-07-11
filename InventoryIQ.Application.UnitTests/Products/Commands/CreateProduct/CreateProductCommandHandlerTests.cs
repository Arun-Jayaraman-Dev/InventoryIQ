using FluentAssertions;
using InventoryIQ.Application.Products.Commands.CreateProduct;
using InventoryIQ.Application.Products.Commands.CreateProduct.Exceptions;
using InventoryIQ.Application.Products.Interfaces;
using InventoryIQ.Domain.Entities;
using Moq;
using Xunit;

namespace InventoryIQ.Application.UnitTests.Products.Commands.CreateProduct
{
    public sealed class CreateProductCommandHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly CreateProductCommandHandler _handler;
        public CreateProductCommandHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _handler = new CreateProductCommandHandler(_productRepositoryMock.Object);
        }

        private static CreateProductCommand CreateValidCommand()
        {
            return new CreateProductCommand("Test Product", "SKU123", 10.99m, 100);
        }

        [Fact]
        public async Task Handle_WithValidCommand_ShouldReturnProductId()
        {
            // Arrange
            var command = CreateValidCommand();

            _productRepositoryMock.Setup(repo => repo.ExistsBySkuAsync(command.Sku)).ReturnsAsync(false);

            _productRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command);

            // Assert
            result.Should().NotBe(Guid.Empty);
            _productRepositoryMock.Verify(repo => repo.ExistsBySkuAsync(command.Sku), Times.Once);
            _productRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WithExistingSku_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var command = CreateValidCommand();

            _productRepositoryMock.Setup(repo => repo.ExistsBySkuAsync(command.Sku)).ReturnsAsync(true);

            // Act
            Func<Task> act = async () => await _handler.Handle(command);

            // Assert
            await act.Should().ThrowAsync<DuplicateProductSkuException>().WithMessage("Product with the same SKU already exists.");
            _productRepositoryMock.Verify(repo => repo.ExistsBySkuAsync(command.Sku), Times.Once);
            _productRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public async Task Handle_ShouldBe_CalledExactlyOnce_WhenCommandIsValid()
        {
            // Arrange
            var command = CreateValidCommand();

            _productRepositoryMock.Setup(repo => repo.ExistsBySkuAsync(command.Sku)).ReturnsAsync(false);
            _productRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            // Act
            await _handler.Handle(command);

            // Assert
            _productRepositoryMock.Verify(repo => repo.ExistsBySkuAsync(command.Sku), Times.Once);
            _productRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);
        }
    }
}