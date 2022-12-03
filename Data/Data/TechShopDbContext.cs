using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data.Mock;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Data
{
    public class TechShopDbContext : IdentityDbContext
    {
        //public TechShopDbContext() { }
        public TechShopDbContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    string connStr = "Server=tcp:myserver4343.database.windows.net,1433;Initial Catalog=laptops_db;Persist Security Info=False;User ID=super_user;Password=Abc123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //    optionsBuilder.UseSqlServer(connStr);
        //}
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
