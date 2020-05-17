using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bd.Api.Data;
using Bd.Api.Domain;
using Bd.Api.Data.Infrastructure.Repository.PricesRepository;
using Bank.Data.Infrastructure.Repository;
using System.Threading;
using AutoMapper;
using Bd.Api.DtoModels;

namespace Bd.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPricesRepository _pricesRepository;
        private readonly IUnitOfWork<Prices> _unitOfWorkPrices;
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;


        private readonly BdContext _context;

        public PricesController(BdContext context, IMapper mapper,
            IPricesRepository pricesRepository, IUnitOfWork<Prices> unitOfWork)
        {
            _mapper = mapper;
            _pricesRepository = pricesRepository;
            _unitOfWorkPrices = unitOfWork;
            _context = context;
        }

        // GET: api/Prices
        [HttpGet]
        public async Task<IEnumerable<PricesDto>> GetPrices()
        {
            return _mapper.Map<IEnumerable<PricesDto>>(await _pricesRepository.FindAllAsync());
            //return await _context.Prices.ToListAsync();
        }


        // GET: api/Prices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PricesDto>> GetPrices(string id)
        {
            var prices = _mapper.Map<PricesDto>(await _pricesRepository.FindAsync(id));
            //var prices = await _context.Prices.FindAsync(id);

            if (prices == null)
            {
                return NotFound();
            }

            return prices;
        }


        [HttpGet("GetPricesByIdAndType/{id}/{type}")]
        public async Task<ActionResult<PricesDto>> GetPricesByIdAndType(string id, string type)
        {
            var prices = _mapper.Map<PricesDto>(await _pricesRepository.FindByIdAndTypeAsync(id, type));

            if (prices == null)
            {
                return NotFound();
            }

            return prices;
        }


        [HttpGet("GetPricesByType/{type}")]
        public async Task<ActionResult<PricesDto>> GetPricesByType(string id, string type)
        {
            var prices = _mapper.Map<PricesDto>(await _pricesRepository.FindByTypeAsync(type));

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
        public async Task<IActionResult> PutPrices(string id, PricesDto prices)
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
        public async Task<ActionResult<PricesDto>> PostPrice(PricesDto prices)
        {


            await _pricesRepository.AddAsync(_mapper.Map<Prices>(prices));
            await _unitOfWorkPrices.CommitAsync(_cancellationToken);
            //_context.Prices.Add(prices);
            //await _context.SaveChangesAsync();

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
