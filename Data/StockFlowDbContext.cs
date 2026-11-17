using Microsoft.EntityFrameworkCore;
using StockFlow.Api.Models;

namespace StockFlow.Api.Data
{
    public class StockFlowDbContext : DbContext
    {
        public StockFlowDbContext(DbContextOptions<StockFlowDbContext> options)
       : base(options)
        {
        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Inventory> Inventories => Set<Inventory>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Warehouse> Warehouses => Set<Warehouse>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(150);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(150);

            modelBuilder.Entity<Supplier>()
                .Property(s => s.Name)
                .HasMaxLength(150);

            modelBuilder.Entity<Warehouse>()
                .Property(w => w.Name)
                .HasMaxLength(150);

            modelBuilder.Entity<Product>()
           .Property(p => p.SKU)
           .IsRequired()
           .HasMaxLength(50);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.SKU)
                .IsUnique();

            modelBuilder.Entity<Product>()
           .Property(p => p.Price)
           .HasPrecision(7, 2);

            modelBuilder.Entity<Product>()
        .Property(p => p.Cost)
        .HasPrecision(6, 2);







            modelBuilder.Entity<Inventory>()
                .HasIndex(i => new { i.ProductId, i.WarehouseId })
                .IsUnique();

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Inventories)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);




            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Warehouse)
                .WithMany(w => w.Inventories)
                .HasForeignKey(i => i.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
