using Bd.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Api.Data
{

    public class UserIdentityDbContext : DbContext
    {

        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserClaim> Claims { get; set; }

        public DbSet<UserLogin> Logins { get; set; }
    }
}
