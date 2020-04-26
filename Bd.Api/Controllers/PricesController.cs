using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bd.Api.Data;
using Bd.Api.Domain;
using Bd.Api.Data.Infrastructure.Repository.PricesRepository;
using System.Threading;
using AutoMapper;
using Bd.Api.DtoModels;

namespace Bd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly BdContext _context;

        private readonly IPricesRepository _pricesRepository;
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;

        public PricesController(BdContext context,
            IMapper mapper,
            IPricesRepository pricesRepository)
        {
            _mapper = mapper;
            _pricesRepository = pricesRepository;
            _context = context;
        }

        // GET: api/Prices
        [HttpGet]
        public async Task<IEnumerable<PricesDto>> GetPrices()
        {
            return _mapper.Map<IEnumerable<PricesDto>>(await _pricesRepository.FindAllAsync());
        }

        // GET: api/Prices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PricesDto>> GetPrices(string id)
        {
            var prices = _mapper.Map<PricesDto>(await _pricesRepository.FindAsync(id));

            if (prices == null)
            {
                return NotFound();
            }

            return prices;
        }

        // PUT: api/Prices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrices(string id, Prices prices)
        {
            if (id != prices.PricesId)
            {
                return BadRequest();
            }

            _context.Entry(prices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PricesExists(id))
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

        // POST: api/Prices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Prices>> PostPrices(Prices prices)
        {
            _context.Prices.Add(prices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrices", new { id = prices.PricesId }, prices);
        }

        // DELETE: api/Prices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prices>> DeletePrices(string id)
        {
            var prices = await _context.Prices.FindAsync(id);
            if (prices == null)
            {
                return NotFound();
            }

            _context.Prices.Remove(prices);
            await _context.SaveChangesAsync();

            return prices;
        }

        private bool PricesExists(string id)
        {
            return _context.Prices.Any(e => e.PricesId == id);
        }
    }
}
