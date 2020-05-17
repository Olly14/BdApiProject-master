using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bd.Api.Data;
using Bd.Api.Domain;
using Bd.Api.Data.Infrastructure.Repository.AppUserRepositiry;
using Bank.Data.Infrastructure.Repository;
using System.Threading;
using AutoMapper;
using Bd.Api.DtoModels;

namespace Bd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ApiBaseController
    {
        private readonly BdContext _context;

        private readonly IAppUserRepository _appUserRepository;
        private readonly IUnitOfWork<AppUser> _unitOfWorkAppUser;
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;









        public AppUsersController(IHttpContextAccessor httpContextAccessor, BdContext context, 
            IAppUserRepository appUserRepository, 
            IUnitOfWork<AppUser> unitOfWorkAppUser,
            IMapper mapper) : base(httpContextAccessor)
        {
            _appUserRepository = appUserRepository;
            _unitOfWorkAppUser = unitOfWorkAppUser;
            _cancellationToken = new CancellationToken();
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/AppUsers
        [HttpGet]
        public async Task<IEnumerable<AppUserDto>> GetAppUsers()
        {
            return _mapper.Map<IEnumerable<AppUserDto>>( await _appUserRepository.FindAppUsersWithOrderAsync());
            //return await _context.AppUsers.ToListAsync();
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserDto>> GetAppUser(string id)
        {
            var appUser = await _appUserRepository.FindAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AppUserDto>(appUser));
        }

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(AppUserDto appUser)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var updateModel = _mapper.Map<AppUser>(appUser);

                    var updatedAppUser = await _unitOfWorkAppUser.
                        UpdateAsync(_cancellationToken, updateModel);

                    return NoContent();
                }
                catch (Exception ex)
                {
                    var errorMsg = ex.Message;
                    throw;
                }
            }


            return NotFound();




        }

        // POST: api/AppUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(AppUser appUser)
        {
            await _appUserRepository.AddAsync(appUser);
            await _unitOfWorkAppUser.CommitAsync(_cancellationToken);

            return CreatedAtAction("GetAppUser", new { id = appUser.AppUserId }, appUser);
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppUser>> DeleteAppUser(string id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();

            return appUser;
        }

        private bool AppUserExists(string id)
        {
            return _context.AppUsers.Any(e => e.AppUserId == id);
        }
    }
}
