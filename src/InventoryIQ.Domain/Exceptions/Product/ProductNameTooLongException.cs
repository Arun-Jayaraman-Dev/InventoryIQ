using InventoryIQ.Domain.Entities.Product;

namespace InventoryIQ.Domain.Exceptions.Product
{
    public sealed class ProductNameTooLongException : Exception
    {
        public ProductNameTooLongException()
            : base($"Product name cannot exceed {ProductConstants.MaxNameLength} characters.")
        {
        }
    }
}