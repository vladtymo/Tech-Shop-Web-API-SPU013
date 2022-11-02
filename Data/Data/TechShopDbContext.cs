using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data.Mock;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Data
{
    public class TechShopDbContext : DbContext
    {
        public TechShopDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OperationSystem>().HasData(MockData.GetOSs());
            modelBuilder.Entity<Laptop>().HasData(MockData.GetLaptops());
        }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<OperationSystem> OperationSystems { get; set; }
    }
}
