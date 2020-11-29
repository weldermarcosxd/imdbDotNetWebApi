using ImbdDomain.Enums;
using ImbdDomain.Models;
using System;
using System.Collections.Generic;

namespace ImdbInfraData.Seeds
{
    public static class UserSeed
    {
        private static User GenerateAdministrator()
        {
            return new User()
            {
                Id = new Guid("c177b3c0-5fac-4604-9287-2ddd76f19d14"),
                Username = "admin",
                Password = "admin",
                Role = UserRolesEnum.Administrator,
                Deleted = false,
                CreatedAt = new DateTime(2020, 11, 29),
                UpdatedAt = new DateTime(2020, 11, 29)
            };
        }

        public static IEnumerable<User> GetData()
        {
            return new List<User>()
            {
                GenerateAdministrator()
            };
        }
    }
}
