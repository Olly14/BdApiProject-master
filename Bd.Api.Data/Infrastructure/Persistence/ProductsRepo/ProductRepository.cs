using Bank.Api.Data.Infrastructure.Persistence;
using Bd.Api.Data.Infrastructure.Repository.ProductRepository;
using Bd.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Persistence.ProductsRepo
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(BdContext bdContext) : base(bdContext)
        {
            
        }

        public async Task<IEnumerable<Product>> FindPoductsWithOrderItemsAsync()
        {
            return await Task.Run(() => BdContext.Products.Include(p => p.OrderItems).OrderBy(p => p.Name));
        }
    }
}
