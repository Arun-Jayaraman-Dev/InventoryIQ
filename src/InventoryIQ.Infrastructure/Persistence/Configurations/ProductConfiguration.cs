using InventoryIQ.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryIQ.Infrastructure.Persistence.Configurations
{
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(ProductConstants.MaxNameLength);

            builder.Property(product => product.Sku)
                .IsRequired()
                .HasMaxLength(ProductConstants.MaxSkuLength);

            builder.HasIndex(product => product.Sku).IsUnique();

            builder.Property(product => product.Price).HasPrecision(18, 2);

            builder.Property(product => product.Quantity).IsRequired();
        }
    }
}
