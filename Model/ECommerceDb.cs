using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Model
{
    public class ECommerceDb : DbContext
    {
        public DbSet<Catogery> catogeries { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Vendor> vendors { get; set; }
        public DbSet<Wishlist> wishlists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

            optionBuilder.UseSqlServer("Data Source=SQL8002.site4now.net;" +
                "Initial Catalog=db_a8d185_ecommercedb;" +
                "User Id=db_a8d185_ecommercedb_admin;" +
                "Password=********;");
         
        }
    }
}
