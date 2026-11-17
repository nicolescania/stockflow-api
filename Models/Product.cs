namespace StockFlow.Api.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;


        public int CategoryId { get; set; }
        public int SupplierId { get; set; }


        public Category Category { get; set; }
        public Supplier Supplier { get; set; }

        public List<Inventory> Inventories { get; set; } = new();
    }
}
