using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop_2._0.Models;

namespace TheWayShop_2._0.DB
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Thing> Thing { get; set; }
        public DbSet<Category> Category { get; set; }
       
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<CartItem> CartItem { get; set; }
        //public DbSet<Order> Order { get; set; }
        //public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
