using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bd.Api.Data;
using Bd.Api.Domain;
using Bd.Api.Data.Infrastructure.Repository.ProductRepository;
using Bank.Data.Infrastructure.Repository;
using System.Threading;
using AutoMapper;
using Bd.Api.DtoModels;

namespace Bd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BdContext _context;

        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork<Product> _unitOfWorkProduct;
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;


        public ProductsController(BdContext context,
                    IProductRepository productRepository,
                    IUnitOfWork<Product> unitOfWorkProduct,
                    IMapper mapper)
        {
            _context = context;
            _productRepository = productRepository;
            _unitOfWorkProduct = unitOfWorkProduct;
            _mapper = mapper;
            _cancellationToken = new CancellationToken();
        }

        // GET: api/Products
        [HttpGet]
        //[Route("api/Products")]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.FindAllAsync());
            //return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(string id)
        {
            var product = _mapper.Map<ProductDto>(await _productRepository.FindAsync(id));
            //var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(string id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(string id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
