namespace InventoryIQ.Domain.Exceptions.Product
{
    public class InvalidProductQuantityException : Exception
    {
        public InvalidProductQuantityException() : base("Stock adjustment amount must be greater than zero.")
        {
        }
    }
}
