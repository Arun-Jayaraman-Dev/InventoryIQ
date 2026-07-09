using InventoryIQ.Domain.Entities;

namespace InventoryIQ.Application.Products.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> ExistsBySkuAsync(string sku);
        Task AddAsync(Product product);
    }
}