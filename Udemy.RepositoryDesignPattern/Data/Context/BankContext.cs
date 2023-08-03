using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Udemy.RepositoryDesignPattern.Data.Entities;

namespace Udemy.RepositoryDesignPattern.Data.Context
{
    public class BankContext : DbContext
    {
       
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<AppUser>? AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
