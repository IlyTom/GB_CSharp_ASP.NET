using Microsoft.EntityFrameworkCore;


namespace Products.Models
{
    public partial class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        private string _connectionString;

        public ProductContext()
        {

        }

        public ProductContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySQL(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ProductID");
                
                entity.HasIndex(e => e.Name).IsUnique();

                entity.ToTable("Products");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.Price).HasColumnName("Price");

            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }            
}
