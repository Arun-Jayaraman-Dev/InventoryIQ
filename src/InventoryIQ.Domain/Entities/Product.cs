using InventoryIQ.Domain.Exceptions;

namespace InventoryIQ.Domain.Entities
{
    public sealed class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Sku { get; private set; } = null!;
        public decimal Price { get; private set; }

        //Required by EF Core
        private Product()
        {
        }

        public Product(string name, string sku, decimal price)
        {
            Id = Guid.NewGuid();

            SetName(name);
            SetSku(sku);
            SetPrice(price);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidProductNameException();
            }

            Name = name;
        }

        private void SetSku(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                throw new InvalidProductSkuException();
            }

            Sku = sku;
        }
            

        private void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new InvalidProductPriceException();
            }

            Price = price;
        }

        public void Rename(string newName)
        {
            SetName(newName);
        }

        public void ChangePrice(decimal newPrice)
        {
            SetPrice(newPrice);
        }
    }
}