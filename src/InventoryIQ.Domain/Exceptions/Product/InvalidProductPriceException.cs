namespace InventoryIQ.Domain.Exceptions.Product
{
    public class InvalidProductPriceException : Exception
    {
        public InvalidProductPriceException() : base("Product price cannot be negative.")
        {
        }
    }
}