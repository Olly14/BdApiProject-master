using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bd.Api.Data.Infrastructure.Repository.AppUserRepositiry;
using Bd.Api.Data.Infrastructure.Repository.OrderRepository;
using Bd.Api.DtoModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bd.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;


        public UtilitiesController(IMapper mapper,
            IAppUserRepository appUserRepository,
            IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _orderRepository = orderRepository;
        }


        // GET: api/Utilities
        [HttpGet]
        public AppUserNameDto GetOrderAppUserNameAsync()
        {
            return new AppUserNameDto() { FullName = "Olly" };
        }

        [HttpGet("{id}")]
        public async Task<AppUserNameDto> Get(string id)
        {
            var order = await _orderRepository.FindAsync(id);
            var appUser = await _appUserRepository.FindAsync(order.AppUserId);
            var appUserName = new AppUserNameDto() { FullName = appUser.UserName };
            return appUserName;
        }
        // GET: api/Utilities/5
        [HttpGet("GetOrderAppUserNameAsync/{id}")]
        public async Task<AppUserNameDto> GetOrderAppUserNameAsync(string id)
        {
            var order = await _orderRepository.FindAsync(id);
            var appUser = await _appUserRepository.FindAsync(order.AppUserId);
            var appUserName = new AppUserNameDto() { FullName = appUser.UserName };
            return appUserName;
        }

        // POST: api/Utilities
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Utilities/5
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
