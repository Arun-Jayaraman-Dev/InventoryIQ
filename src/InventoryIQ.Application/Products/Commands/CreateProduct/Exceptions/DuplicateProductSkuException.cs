namespace InventoryIQ.Application.Products.Commands.CreateProduct.Exceptions
{
    public class DuplicateProductSkuException: Exception
    {
        public DuplicateProductSkuException() : base("Product with the same SKU already exists.")
        { 
        }
    }
}
