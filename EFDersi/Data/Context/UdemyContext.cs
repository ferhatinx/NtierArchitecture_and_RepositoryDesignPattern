using EFDersi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFDersi.Data.Context
{
    public class UdemyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<SaleHistory> SaleHistories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=DESKTOP-3KU2KP7; database=UdemyEFCore; integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasDefaultValueSql("20.00");
            
            modelBuilder.Entity<Product>().HasMany(x => x.SaleHistories).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<Customer>().HasKey(x => x.Number); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
