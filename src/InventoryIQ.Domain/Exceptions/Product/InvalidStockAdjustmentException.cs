namespace InventoryIQ.Domain.Exceptions.Product
{
    public class InvalidStockAdjustmentException : Exception
    {
        public InvalidStockAdjustmentException() : base("Product stock should be a positive value.")
        {
        }
    }
}
