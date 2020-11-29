using ImbdDomain.Models;
using ImdbInfraData.Interfaces;
using System.Linq;

namespace ImdbServices.Services
{
    public class UserService : ImdbCrudService<User>, IUserService
    {
        private readonly IImdbRepository<User> _repository;

        public UserService(IImdbRepository<User> repository) : base(repository)
        {
            _repository = repository;
        }

        public User Get(string usename, string password)
        {
            return _repository.GetAll().FirstOrDefault(x => x.Username.ToLower() == usename.ToLower() && x.Password == password);
        }
    }
}
