using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop_2._0.Models;

namespace TheWayShop_2._0.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Thing> Thing { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        //public DbSet<CartItem> CartItem { get; set; }
        //public DbSet<Order> Order { get; set; }
        //public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { id = 1, name = adminRoleName };
            Role userRole = new Role { id = 2, name = userRoleName };
            User adminUser = new User { id = 1, email = adminEmail, password = adminPassword, roleId = adminRole.id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
