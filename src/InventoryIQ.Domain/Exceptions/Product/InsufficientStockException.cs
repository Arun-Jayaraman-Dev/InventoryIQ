namespace InventoryIQ.Domain.Exceptions.Product
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException() : base("Cannot decrease stock below zero.")
        {
        }
    }
}
