namespace InventoryIQ.Domain.Exceptions
{
    public class InvalidProductSkuException : Exception
    {
        public InvalidProductSkuException() : base("SKU cannot be empty or whitespace.")
        {
        }
    }
}
