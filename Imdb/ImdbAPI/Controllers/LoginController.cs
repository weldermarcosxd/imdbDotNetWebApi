using AutoMapper;
using ImbdDomain.Models;
using ImdbServices.Dtos;
using ImdbServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImdbAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate")]
        public ActionResult<dynamic> Authenticate([FromBody] User model)
        {
            var user = _userService.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "User or password invalid" });

            var token = TokenService.GenerateToken(user);
            var userDto = _mapper.Map<UserDto>(user);

            return new
            {
                user = userDto,
                token
            };
        }
    }
}
