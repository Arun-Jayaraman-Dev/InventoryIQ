using InventoryIQ.Domain.Entities.Product;

namespace InventoryIQ.Domain.Exceptions.Product
{
    public class ProductSkuTooLongException: Exception
    {
        public ProductSkuTooLongException(): base($"Product SKU length cannot exceed {ProductConstants.MaxSkuLength}.")
        {

        }
    }
}
