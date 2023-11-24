using GroceryStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.EntityFramework.EntityFramework
{
    public class GroceryStoreManagerDBContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductType> productsTypes { get; set; }
        public GroceryStoreManagerDBContext(DbContextOptions options) : base(options){}  
    }
}
