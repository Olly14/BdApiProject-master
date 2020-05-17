using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bd.Api.Data;
using Bd.Api.Domain;
using Bd.Api.Data.Infrastructure.Repository.OrderItemRepository;
using Bank.Data.Infrastructure.Repository;
using System.Threading;
using AutoMapper;

namespace Bd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemHistoriesController : ControllerBase
    {
        private readonly BdContext _context;

        private readonly IOrderItemHistoryRepository _orderItemHistoryRepository;
        private readonly IUnitOfWork<OrderItemHistory> _unitOfWorkOrderItem;
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;

        public OrderItemHistoriesController(BdContext context, IMapper mapper,
                IOrderItemHistoryRepository orderItemRepository/*, IUnitOfWork<OrderItemHistory> unitOfWork*/)
        {
            _mapper = mapper;
            _orderItemHistoryRepository = orderItemRepository;
            //_unitOfWorkOrderItem = unitOfWork;

            _context = context;
        }

        // GET: api/OrderItemHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        // GET: api/OrderItemHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(string id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }


        [HttpGet("GetOrderItemsByOrderHistoryId/{id}")]
        public async Task<IEnumerable<OrderItemHistory>> GetOrderItemsByOrderHistoryId(string id)
        {
            var orderItems = await _orderItemHistoryRepository.FindOrderItemsByOrderIdAsync(id);

            return orderItems;
        }

        // PUT: api/OrderItemHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(string id, OrderItem orderItem)
        {
            if (id != orderItem.OrderItemId)
            {
                return BadRequest();
            }

            _context.Entry(orderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
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

        // POST: api/OrderItemHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItem", new { id = orderItem.OrderItemId }, orderItem);
        }

        // DELETE: api/OrderItemHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderItem>> DeleteOrderItem(string id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return orderItem;
        }

        private bool OrderItemExists(string id)
        {
            return _context.OrderItems.Any(e => e.OrderItemId == id);
        }
    }
}
