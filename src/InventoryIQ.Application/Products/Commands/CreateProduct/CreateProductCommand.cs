namespace InventoryIQ.Application.Products.Commands.CreateProduct
{
    public sealed record CreateProductCommand
    (
        string Name,
        string Sku,
        decimal Price,
        int Quantity
    );
}
