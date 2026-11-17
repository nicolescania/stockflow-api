namespace StockFlow.Api.Models
{
    public class Warehouse
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Inventory> Inventories { get; set; } = new();
    }
}
