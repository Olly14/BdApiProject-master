﻿using Bd.Api.Domain;
using Microsoft.EntityFrameworkCore;


namespace Bd.Api.Data
{
    public partial class BdContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderHistory> OrderHistories { get; set; }

        public DbSet<OrderItemHistory> OrderItemHistories { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Prices> Prices { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
