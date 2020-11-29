using ImbdDomain.Enums;
using System;

namespace ImdbServices.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserRolesEnum Role { get; set; }
    }
}
