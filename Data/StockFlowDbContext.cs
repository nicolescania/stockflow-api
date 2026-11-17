using Microsoft.EntityFrameworkCore;
using StockFlow.Api.Models;

namespace StockFlow.Api.Data
{
    public class StockFlowDbContext: DbContext
    {
        public StockFlowDbContext(DbContextOptions<StockFlowDbContext> options)
       : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();

    }
}
