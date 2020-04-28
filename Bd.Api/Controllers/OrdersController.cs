﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bank.Data.Infrastructure.Repository;
using Bd.Api.Data.Infrastructure.Repository.OrderRepository;
using Bd.Api.Domain;
using Bd.Api.DtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Bd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork<Order> _unitOfWorkOrder;
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;



        public OrdersController(IOrderRepository orderRepository, IMapper mapper, IUnitOfWork<Order> unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWorkOrder = unitOfWork;
            _mapper = mapper;

            _cancellationToken = new CancellationToken();
        }

        // GET: api/Default
        //[HttpGet("GetOrders")]
        //[Route("GetOrders")]
        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            return _mapper.Map<IEnumerable<OrderDto>>(await _orderRepository.FindAllAsync());
        }

        // GET: api/Default/5
        [HttpGet("{id}")]
        //[Route("GetOrders/{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(string id)
        {
            var order = _mapper.Map<OrderDto>(await _orderRepository.FindAsync(id));

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }




        // POST: api/Default
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrder([FromBody]OrderDto order)
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.AddAsync(_mapper.Map<Order>(order));

                try
                {
                    await _unitOfWorkOrder.CommitAsync(_cancellationToken);
                }
                catch (Exception ex)
                {
                    var errMsg = ex.Message;
                    throw;
                }
            }

            //_context.Orders.Add(order);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(string id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            var newOrder = await _orderRepository.FindAsync(id);

            try
            {
                await _unitOfWorkOrder.UpdateAsync(_cancellationToken, newOrder);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await OrderExistsAsync(id)))
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


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private async Task<bool> OrderExistsAsync(string id)
        {
            var result = await _orderRepository.FindAsync(id);
            return result == null;
        }
    }
}
