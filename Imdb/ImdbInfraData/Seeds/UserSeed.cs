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
                Id = Guid.NewGuid(),
                Username = "admin",
                Password = "admin",
                Role = UserRolesEnum.Administrator.ToString(),
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
