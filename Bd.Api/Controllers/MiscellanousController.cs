using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bd.Api.Data.Infrastructure.Repository.AppUserRepositiry;
using Bd.Api.DtoModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiscellanousController : ControllerBase
    {

        private readonly IAppUserRepository _appUserRepository;

        public MiscellanousController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }


        [HttpGet("GetAppUserSubjectId/{id}")]
        // GET: MiscellanousController
        public async Task<IActionResult> GetAppUserSubjectId(string id)
        {
            var misc = new MiscellanousDto();
            misc.AppUserSubjectId = await _appUserRepository.FindAppUserSubjectIdAsync(id);
            if (string.IsNullOrWhiteSpace(misc.AppUserSubjectId))
            {
                return NotFound();
            }
            return Ok(misc);
        }


        // GET: api/<MiscellanousController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MiscellanousController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MiscellanousController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MiscellanousController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MiscellanousController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
