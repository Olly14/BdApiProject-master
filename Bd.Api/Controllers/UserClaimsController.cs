using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bd.Api.Data;
using Bd.Api.Domain;
using Bd.Api.Data.Infrastructure.Repository.Administrations;
using Bd.Api.Data.Infrastructure.Repository.AppUserRepository;
using AutoMapper;
using Bd.Web.Api.DtoModels;
using Bank.Data.Infrastructure.Repository;
using System.Threading;

namespace Bd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClaimsController : ControllerBase
    {


        private readonly IUserClaimRepository _userClaimRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<UserClaim> _unitOfworkUserClaim;
        private readonly CancellationToken _cancellationToken;
        private readonly UserIdentityDbContext _context;

        public UserClaimsController(UserIdentityDbContext context,
            IUserClaimRepository userClaimRepository,
            IUnitOfWork<UserClaim> unitOfworkUserClaim,
            IMapper mapper)
        {
            _userClaimRepository = userClaimRepository;
            _unitOfworkUserClaim = unitOfworkUserClaim;
            _mapper = mapper;
            _cancellationToken = new CancellationToken();
            _context = context;
        }

        // GET: api/UserClaims
        [HttpGet]
        public async Task<IEnumerable<UserClaim>> GetUserClaims()
        {
            return await _userClaimRepository.FindAllAsync();
        }

        // GET: api/UserClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserClaim>> GetUserClaim(string id)
        {
            //var userClaim = _mapper.Map<UserClaimDto>(await _userClaimRepository.FindAsync(id));
            var userClaim = await _context.Claims.FindAsync(id);

            if (userClaim == null)
            {
                return NotFound();
            }

            return userClaim;
        }

        // PUT: api/UserClaims/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserClaim(string id, UserClaim userClaim)
        {
            if (id != userClaim.Id)
            {
                return BadRequest();
            }

            _context.Entry(userClaim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserClaimExists(id))
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

        // POST: api/UserClaims
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserClaimDto>> PostUserClaim(UserClaimDto userClaim)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("InvalidModel", "Properties not in valid state");
                return userClaim;
            }

            await _userClaimRepository.AddAsync(_mapper.Map<UserClaim>(userClaim));

            try
            {
                await _unitOfworkUserClaim.CommitAsync(_cancellationToken);;

                return CreatedAtAction("GetUserClaim", new { id = userClaim.Id }, userClaim);
            }
            catch (Exception ex)
            {
                var errMsg = ex.Message;
                throw;
            }

        }

        // DELETE: api/UserClaims/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserClaim>> DeleteUserClaim(string id)
        {
            var userClaim = await _context.Claims.FindAsync(id);
            if (userClaim == null)
            {
                return NotFound();
            }

            _context.Claims.Remove(userClaim);
            await _context.SaveChangesAsync();

            return userClaim;
        }

        private bool UserClaimExists(string id)
        {
            return _context.Claims.Any(e => e.Id == id);
        }
    }
}
