using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bank.Data.Infrastructure.Repository;
using Bd.Api.Data.Infrastructure.Repository.PricesRepository;
using Bd.Api.Domain;
using Bd.Api.DtoModels;
using Microsoft.AspNetCore.Mvc;

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


        public PricesController(IMapper mapper,
            IPricesRepository pricesRepository, IUnitOfWork<Prices> unitOfWork)
        {
            _mapper = mapper;
            _pricesRepository = pricesRepository;
            _unitOfWorkPrices = unitOfWork;
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

        // POST: api/Prices
        [HttpPost]
        public async Task<ActionResult<PricesDto>> PostPrices(PricesDto prices)
        {
            if (ModelState.IsValid)
            {
                await _pricesRepository.AddAsync(_mapper.Map<Prices>(prices));

                try
                {
                    await _unitOfWorkPrices.CommitAsync(_cancellationToken);
                }
                catch (Exception ex)
                {
                    var errMsg = ex.Message;
                    throw;
                }
            }

            //_context.Orders.Add(order);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = prices.PricesId }, prices);
        }

        // PUT: api/Prices/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
