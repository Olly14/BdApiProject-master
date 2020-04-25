using System.Threading;
using Bd.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bd.Api.Data
{
    public partial class BdContext : DbContext
    {



        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {

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
            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId).IsRequired();

            modelBuilder.Entity<OrderItem>()
             .HasOne<Product>(oi => oi.Product)
             .WithMany(p => p.OrderItems)
             .HasForeignKey(oi => oi.ProductId).IsRequired();


            modelBuilder.Entity<Order>()
                .HasOne<AppUser>(o => o.AppUser)
                .WithMany(au => au.Orders)
                .HasForeignKey(o => o.AppUserId);


            modelBuilder.Entity<AppUser>()
                .HasOne<Gender>(a => a.Gender)
                .WithMany(c => c.AppUsers)
               .HasForeignKey(a => a.GenderId).IsRequired();

            //modelBuilder.Entity<Account>()
            //    .HasOne<AccountType>(a => a.AccountType)
            //    .WithMany(acctType => acctType.Accounts)
            //    .HasForeignKey(a => a.AccountTypeId).IsRequired();

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
