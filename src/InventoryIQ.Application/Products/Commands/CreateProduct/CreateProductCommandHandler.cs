using InventoryIQ.Application.Products.Commands.CreateProduct.Exceptions;
using InventoryIQ.Application.Products.Interfaces;
using InventoryIQ.Domain.Entities.Product;

namespace InventoryIQ.Application.Products.Commands.CreateProduct
{
    public sealed class CreateProductCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var skuExists = await _productRepository.ExistsBySkuAsync(command.Sku, cancellationToken);

            if (skuExists)
            {
                throw new DuplicateProductSkuException();
            }

            var product = new Product(command.Name, command.Sku, command.Price, command.Quantity);           

            await _productRepository.AddAsync(product, cancellationToken);
            return product.Id;
        }
    }
}