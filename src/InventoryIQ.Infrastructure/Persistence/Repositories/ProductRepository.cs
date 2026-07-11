using InventoryIQ.Application.Products.Interfaces;
using InventoryIQ.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace InventoryIQ.Infrastructure.Persistence.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly InventoryIQDbContext _dbContext;

    public ProductRepository(InventoryIQDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> ExistsBySkuAsync(string sku, CancellationToken cancellationToken)
    {
        return await _dbContext.Products.AnyAsync(product => product.Sku == sku,cancellationToken);
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _dbContext.Products.AddAsync(product,cancellationToken);
    }
}