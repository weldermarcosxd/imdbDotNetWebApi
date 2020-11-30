using AutoMapper;
using ImbdDomain.Enums;
using ImbdDomain.Models;
using ImdbServices.Dtos;
using ImdbServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        protected virtual void GetUserRole(UserDto user)
        {
            user.Role = UserRolesEnum.User;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();


            return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}?id{ user.Id}", user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.First().Errors.First().ErrorMessage);

            user.Id = Guid.NewGuid();
            GetUserRole(user);
            var usuario = _mapper.Map<User>(user);

            await _userService.InsertAsync(usuario);

            return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}?id{ user.Id}", user);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.First().Errors.First().ErrorMessage);

            var usuario = _mapper.Map<User>(user);

            await _userService.UpdateAsync(usuario);

            return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}?id={ user.Id}", user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteAsync(id);

            return NoContent();
        }
    }
}
