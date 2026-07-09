using InventoryIQ.Application.Products.Interfaces;
using InventoryIQ.Domain.Entities;

namespace InventoryIQ.Application.Products.Commands.CreateProduct
{
    public sealed class CreateProductCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand command)
        {
            var skuExists = await _productRepository.ExistsBySkuAsync(command.Sku);

            if (skuExists)
            {
                throw new InvalidOperationException("Product with the same SKU already exists.");
            }

            var product = new Product(command.Name, command.Sku, command.Price, command.Quantity);           

            await _productRepository.AddAsync(product);
            return product.Id;
        }
    }
}