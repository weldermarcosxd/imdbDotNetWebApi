using ImbdDomain.Models;

namespace ImdbServices.Services
{
    public interface IUserService
    {
        User Get(string usename, string password);
    }
}