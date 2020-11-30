using AutoMapper;
using ImbdDomain.Models;
using ImdbInfraData.Interfaces;
using ImdbServices.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ImdbServices.Services
{
    public class MovieService : ImdbCrudService<Movie>, IMovieService
    {
        private readonly IImdbRepository<Movie> _repository;
        private readonly IMapper _mapper;

        public MovieService(IImdbRepository<Movie> repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public MovieDetailsDto ObterDatails(Guid id)
        {
            var detalhes = _repository.GetAll()
                .Include(x => x.Votes)
                .Include(x => x.Staff)
                .FirstOrDefault(x => x.Id == id);

            MovieDetailsDto detail = _mapper.Map<MovieDetailsDto>(detalhes);

            return detail;
        }
    }
}
