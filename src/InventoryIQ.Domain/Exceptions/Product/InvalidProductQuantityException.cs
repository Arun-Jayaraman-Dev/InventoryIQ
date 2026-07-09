namespace InventoryIQ.Domain.Exceptions.Product
{
    public class InvalidProductQuantityException : Exception
    {
        public InvalidProductQuantityException() : base("Product stock cannot be negative.")
        {
        }
    }
}
