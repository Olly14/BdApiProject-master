using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bd.Api.Data;
using Bd.Api.Domain;
using AutoMapper;
using System.Threading;
using Bd.Api.Data.Infrastructure.Repository.OrderHistoryRepository;
using Bank.Data.Infrastructure.Repository;
using Bd.Api.DtoModels;

namespace Bd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoriesController : ApiBaseController
    {
        private readonly BdContext _context;

        private readonly IOrderHistoryRepository _orderHistoryRepository;
        private readonly IUnitOfWork<OrderHistory> _unitOfWorkOrderhistory;
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;

        public OrderHistoriesController(BdContext context,
            IOrderHistoryRepository orderHistoryRepository,
            IUnitOfWork<OrderHistory> unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper) : base(httpContextAccessor)
        {
            _orderHistoryRepository = orderHistoryRepository;
            _unitOfWorkOrderhistory = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;

            _cancellationToken = new CancellationToken();
        }

        // GET: api/OrderHistories
        [HttpGet]
        public async Task<IEnumerable<OrderHistoryDto>> GetOrderHistories()
        {
            return _mapper.Map<IEnumerable<OrderHistoryDto>>(
                await _orderHistoryRepository.FindAllAsync());
        }

        // GET: api/OrderHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderHistoryDto>> GetOrderHistory(string id)
        {
            var orderHistory = _mapper.Map<OrderHistoryDto>(await _orderHistoryRepository.FindAsync(id));

            if (orderHistory == null)
            {
                return NotFound();
            }

            return orderHistory;
        }

        [HttpGet("GetOrderHistoriesByAppUserId/{id}")]
        public async Task<IEnumerable<OrderHistoryDto>> GetOrderHistoriesByAppUserId(string id)
        {
            return _mapper.Map<IEnumerable<OrderHistoryDto>>(
                await _orderHistoryRepository.FindAllAsync());
        }


        // PUT: api/OrderHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderHistory(string id, OrderHistory orderHistory)
        {
            if (id != orderHistory.OrderHistoryId)
            {
                return BadRequest();
            }

            _context.Entry(orderHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderHistoryExists(id))
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

        // POST: api/OrderHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderHistoryDto>> PostOrderHistory(OrderHistoryDto orderHistory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _orderHistoryRepository.AddAsync(_mapper.Map<OrderHistory>(orderHistory));
                    await _unitOfWorkOrderhistory.CommitAsync(_cancellationToken);
                    return CreatedAtAction("GetOrderHistory", new { id = orderHistory.OrderHistoryId }, orderHistory);
                }
                catch (Exception ex)
                {
                    var errorMsg = ex.Message;
                    throw;
                }

            }

            return BadRequest();
        }

        // DELETE: api/OrderHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderHistory>> DeleteOrderHistory(string id)
        {
            var orderHistory = await _context.OrderHistories.FindAsync(id);
            if (orderHistory == null)
            {
                return NotFound();
            }

            _context.OrderHistories.Remove(orderHistory);
            await _context.SaveChangesAsync();

            return orderHistory;
        }

        private bool OrderHistoryExists(string id)
        {
            return _context.OrderHistories.Any(e => e.OrderHistoryId == id);
        }
    }
}
