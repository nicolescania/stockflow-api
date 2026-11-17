namespace StockFlow.Api.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string SKU { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }


        public required Category Category { get; set; }
        public required Supplier Supplier { get; set; }

        public List<Inventory> Inventories { get; set; } = new();
    }
}
