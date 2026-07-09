using InventoryIQ.Domain.Exceptions.Product;

namespace InventoryIQ.Domain.Entities
{
    public sealed class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Sku { get; private set; } = null!;
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        //Required by EF Core
        private Product()
        {
        }

        public Product(string name, string sku, decimal price, int quantity)
        {
            Id = Guid.NewGuid();

            SetName(name);

            SetSku(sku);

            SetPrice(price);

            SetQuantity(quantity);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidProductNameException();
            }

            Name = name.Trim();
        }

        private void SetSku(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                throw new InvalidProductSkuException();
            }

            Sku = sku.Trim();
        }


        private void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new InvalidProductPriceException();
            }

            Price = price;
        }

        private void SetQuantity(int quantity)
        {
            if (quantity < 0)            
            {
                throw new InvalidProductQuantityException();
            }

            Quantity = quantity;
        }

        public void Rename(string newName)
        {
            SetName(newName);
        }

        public void ChangePrice(decimal newPrice)
        {
            SetPrice(newPrice);
        }

        public void IncreaseStock(int amount)
        {
            if (amount <= 0)
            {
                throw new InvalidProductQuantityException();
            }

            Quantity += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount <= 0)
            {
                throw new InvalidProductQuantityException();
            }

            if (Quantity < amount)
            {
                throw new InsufficientStockException();
            }

            if(amount > Quantity)
            {
                throw new InsufficientStockException();
            }

            Quantity -= amount;
        }
    }
}