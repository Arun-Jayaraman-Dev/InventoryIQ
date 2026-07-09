namespace InventoryIQ.Domain.Exceptions.Product
{
    public class InvalidStockAdjustmentException : Exception
    {
        public InvalidStockAdjustmentException() : base("Stock adjustment amount must be greater than zero.")
        {
        }
    }
}
