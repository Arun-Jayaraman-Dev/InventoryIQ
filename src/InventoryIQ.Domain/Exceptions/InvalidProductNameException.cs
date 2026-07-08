namespace InventoryIQ.Domain.Exceptions
{
    public class InvalidProductNameException : Exception
    {
        public InvalidProductNameException() : base("Product name cannot be empty or whitespace.")
        {
        }
    }
}
