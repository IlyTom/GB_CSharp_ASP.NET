using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;

namespace ProductStore.Models
{
    public partial class ProductStoreContext : DbContext
    {
        public DbSet<StoreItem> StoreItems { get; set; }

        private string _connectionString;

        public ProductStoreContext() { }

        public ProductStoreContext(string connectionString) => _connectionString = connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseMySQL(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreItem>(entity =>
            {
                entity.HasKey(e => e.ItemId).HasName("ItemId");
                entity.HasIndex(e => e.ItemId).IsUnique();
                

                entity.ToTable("StoreItems");
                entity.Property(e => e.ItemId).HasColumnName("ItemId");
                entity.Property(e => e.ProductId).HasColumnName("ProductId");
                entity.Property(e => e.StoreId).HasColumnName("StoreId");
                entity.Property(e => e.Quantity).HasColumnName("Quantity");


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
