using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models.Entities;

namespace OnlineShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AccountEntity> Accounts => Set<AccountEntity>();
        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<DiscountEntity> Discounts => Set<DiscountEntity>();
        public DbSet<BillEntity> Bills => Set<BillEntity>();
        public DbSet<ItemEntity> Items => Set<ItemEntity>();
    }
}
