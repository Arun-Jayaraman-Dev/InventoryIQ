namespace InventoryIQ.Domain.Exceptions.Product
{
    public class InvalidProductSkuException : Exception
    {
        public InvalidProductSkuException() : base("SKU cannot be empty or whitespace.")
        {
        }
    }
}
