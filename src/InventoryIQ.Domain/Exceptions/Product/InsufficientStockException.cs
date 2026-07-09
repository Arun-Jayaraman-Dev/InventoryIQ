namespace InventoryIQ.Domain.Exceptions.Product
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException() : base("Product stock cannot be negative.")
        {
        }
    }
}
