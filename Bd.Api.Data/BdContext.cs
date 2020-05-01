using System.Threading;
using Bd.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bd.Api.Data
{
    public partial class BdContext : DbContext
    {



        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureEntitiesRelationship(modelBuilder);
        }

        public void MapTableNames(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }


        private void ConfigureEntitiesRelationship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new {op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

           // modelBuilder.Entity<OrderProduct>()
           //  .HasOne<Product>(op => op.Product)
           //  .WithMany(p => p.OrderProducts)
           //  .HasForeignKey(oi => oi.ProductId);

           //modelBuilder.Entity<OrderProduct>()
           // .HasOne<Order>(op => op.Order)
           // .WithMany(o => o.OrderProducts)
           // .HasForeignKey(o => o.ProductId);


            modelBuilder.Entity<Order>()
                .HasOne<AppUser>(o => o.AppUser)
                .WithMany(au => au.Orders)
                .HasForeignKey(o => o.AppUserId);


            modelBuilder.Entity<AppUser>()
                .HasOne<Gender>(a => a.Gender)
                .WithMany(c => c.AppUsers)
               .HasForeignKey(a => a.GenderId).IsRequired();


            //modelBuilder.Entity<Account>()
            //    .HasOne<Currency>(a => a.Currency)
            //    .WithMany(cu => cu.Accounts)
            //    .HasForeignKey(a => a.CurrencyId).IsRequired();

            //modelBuilder.Entity<AccountTransaction>()
            //    .HasOne<Account>(at => at.Account)
            //    .WithMany(a => a.AccountTransactions)
            //    .HasForeignKey(a => a.AccountId).IsRequired();


            //modelBuilder.Entity<AccountTransaction>()
            //    .HasOne<OrderByType>(at => at.OrderByType)
            //    .WithMany(ot => ot.AccountTransactions)
            //    .HasForeignKey(ot => ot.OrderByTypeId).IsRequired();

        }

        public virtual void Commit(CancellationToken cancellationToken)
        {
            base.SaveChangesAsync(cancellationToken);
        }


    }
}
