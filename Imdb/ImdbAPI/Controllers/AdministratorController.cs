using AutoMapper;
using ImbdDomain.Enums;
using ImdbServices.Dtos;
using ImdbServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ImdbAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AdministratorController : UsersController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AdministratorController(IUserService userService, IMapper mapper) : base(userService, mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        protected override void GetUserRole(UserDto user)
        {
            user.Role = UserRolesEnum.Administrator;
        }

        [HttpGet]
        [Route("GetChildUsers")]
        public IEnumerable<UserDto> GetChildUsers([FromQuery] int pageSize = 50, [FromQuery] int page = 0)
        {
            var usuarios = _userService.GetAll().Where(x => x.Role == UserRolesEnum.User).OrderBy(x => x.Username);
            return _mapper.ProjectTo<UserDto>(usuarios.Skip(page * pageSize).Take(pageSize));
        }
    }
}
