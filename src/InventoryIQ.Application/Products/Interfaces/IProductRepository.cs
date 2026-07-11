using InventoryIQ.Domain.Entities.Product;

namespace InventoryIQ.Application.Products.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> ExistsBySkuAsync(string sku, CancellationToken cancellationToken);
        Task AddAsync(Product product, CancellationToken cancellationToken);
    }
}