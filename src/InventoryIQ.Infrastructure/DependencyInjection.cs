using InventoryIQ.Application.Products.Interfaces;
using InventoryIQ.Infrastructure.Persistence;
using InventoryIQ.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryIQ.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventoryIQDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("InventoryIQ"));
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
