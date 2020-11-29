using ImbdDomain.Enums;

namespace ImbdDomain.Models
{
    public class User : ImdbEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public UserRolesEnum Role { get; set; }
    }
}
