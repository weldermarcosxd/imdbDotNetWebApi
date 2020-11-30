using AutoMapper;
using ImbdDomain.Models;
using ImdbInfraData.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbServices.Services
{
    public class VoteService : ImdbCrudService<Vote>, IVoteService
    {
        private readonly IImdbRepository<Vote> _repository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public VoteService(IImdbRepository<Vote> repository, IMapper mapper, IUserService userService, IMovieService movieService) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
            _userService = userService;
            _movieService = movieService;
        }

        public async Task<Vote> AddVote(Guid movieId, Guid userId, int score)
        {
            var user = _userService.GetAll().FirstOrDefault(x => x.Id == userId);
            var movie = _movieService.GetAll().FirstOrDefault(x => x.Id == movieId);

            if (user == null || movie == null)
                throw new NullReferenceException("Usuário ou Filme não encontrados");

            if (score > 4 || score < 0)
                throw new ArgumentOutOfRangeException("A classificação deve estar entre 0 e 4");

            Vote existingVote = GetAll().AsNoTracking().FirstOrDefault(x => x.UserId == user.Id && x.MovieId == movie.Id);

            Vote vote = new Vote()
            {
                MovieId = movie.Id,
                UserId = user.Id,
                Score = score
            };

            if (existingVote != null)
            {
                vote.Id = existingVote.Id;
                return await UpdateAsync(vote);
            }
            else
                return await InsertAsync(vote);
        }
    }
}
