namespace InventoryIQ.Domain.Exceptions
{
    public class InvalidProductPriceException : Exception
    {
        public InvalidProductPriceException() : base("Product price cannot be negative.")
        {
        }
    }
}