using KMA.Models;
using KMA.Models.OrderManager;
using KMA.Models.ProductManager;
using KMA.Models.StockManager;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Database
{
    public class KMADbContext: IdentityDbContext<User>
    {
        private readonly DbContextOptions _options;
        public KMADbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        //User
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UsersLoginHistory> UsersLoginHistory { get; set; }

        //Product
        public DbSet<Product> Product { get; set; }
        public DbSet<MenuPostion> MenuPostion { get; set; }
        public DbSet<MenuPostionToProduct> MenuPostionToProduct { get; set; }
        
        //Order
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderToMenuPostion> OrderToMenuPostion { get; set; }
        
        //Stock
        public DbSet<ProductStock> ProductStock { get; set; }
    }
}
