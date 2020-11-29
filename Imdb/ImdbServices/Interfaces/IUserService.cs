using ImbdDomain.Models;
using ImdbServices.Interfaces;

namespace ImdbServices.Services
{
    public interface IUserService : IImdbCrudService<User>
    {
        User Get(string usename, string password);
    }
}