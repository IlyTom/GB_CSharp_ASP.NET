using Microsoft.EntityFrameworkCore;

namespace Store.Models
{
    public partial class StoreContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }

        private string _connectionString;

        public StoreContext()
        {

        }

        public StoreContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySQL(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("StoreID");
                entity.HasIndex(e => e.Id).IsUnique();
                entity.HasIndex(e => e.Url).IsUnique();

                entity.ToTable("Stores");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Title).HasColumnName("Title");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.Url).HasColumnName("Url");

            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
