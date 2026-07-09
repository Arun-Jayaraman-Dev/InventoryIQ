namespace InventoryIQ.Domain.Exceptions.Product
{
    public class InvalidProductNameException : Exception
    {
        public InvalidProductNameException() : base("Product name cannot be empty or whitespace.")
        {
        }
    }
}
