using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bank.Data.Infrastructure.Repository;
using Bd.Api.Data.Infrastructure.Repository.OrderItemRepository;
using Bd.Api.Domain;
using Bd.Api.DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {

        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IUnitOfWork<OrderItem> _unitOfWorkOrderItem;
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;


        public OrderItemsController(IMapper mapper,
                IOrderItemRepository orderItemRepository, IUnitOfWork<OrderItem> unitOfWork)
        {
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
            _unitOfWorkOrderItem = unitOfWork;
        }


        // GET: api/OrderItems
        [HttpGet]
        public async Task<IEnumerable<OrderItemDto>> GetOrderItems()
        {
            return _mapper.Map<IEnumerable<OrderItemDto>>(await _orderItemRepository.FindAllAsync());
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> GetOrderItems(string id)
        {
            var orderItem = _mapper.Map<OrderItemDto>(await _orderItemRepository.FindAsync(id));

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        [HttpGet("GetOrderItemsByOrderId/{id}")]
        public async Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderId(string id)
        {
           return _mapper.Map<IEnumerable<OrderItemDto>>(await _orderItemRepository.FindOrderItemsByOrderIdAsync(id));

        }

        // POST: api/OrderItems
        [HttpPost]
        public OrderItemDto OrderItemDto([FromBody] OrderItemDto value)
        {
            throw NotImplementedException();
        }

        private Exception NotImplementedException()
        {
            throw new NotImplementedException();
        }

        // PUT: api/OrderItems/5
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
