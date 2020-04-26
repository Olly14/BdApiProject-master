using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bd.Api.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bd.Api.DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownListsController : ControllerBase
    {
        private readonly IGenderRepository _genderRepository;
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;

        public DropDownListsController(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
            _cancellationToken = new CancellationToken();
        }

        // GET: api/DropDownLists
        [HttpGet]
        public async Task<IEnumerable<GenderDto>> GetAsync()
        {
            return _mapper.Map<IEnumerable<GenderDto>>(await _genderRepository.FindAllAsync());
           
        }

        // GET: api/DropDownLists/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<GenderDto> GetAsync(string id)
        {
            return _mapper.Map<GenderDto>(await _genderRepository.FindAsync(id));
        }

        // POST: api/DropDownLists
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/DropDownLists/5
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
