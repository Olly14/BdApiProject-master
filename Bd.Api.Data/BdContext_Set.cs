using Bd.Api.Domain;
using Microsoft.EntityFrameworkCore;


namespace Bd.Api.Data
{
    public partial class BdContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Gender> Genders { get; set; }
    }
}
