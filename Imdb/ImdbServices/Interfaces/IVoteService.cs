using ImbdDomain.Models;
using ImdbServices.Interfaces;
using System;
using System.Threading.Tasks;

namespace ImdbServices.Services
{
    public interface IVoteService : IImdbCrudService<Vote>
    {
        Task<Vote> AddVote(Guid userId, Guid movieId, int score);
    }
}