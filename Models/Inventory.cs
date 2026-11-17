namespace StockFlow.Api.Models
{
    public class Inventory
    {

        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }

        public int ProductId { get; set; }
        public int WarehouseId { get; set; }


        public required Product Product { get; set; }
        public required Warehouse Warehouse { get; set; }
    }
}
