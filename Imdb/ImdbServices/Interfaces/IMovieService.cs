using ImbdDomain.Models;
using ImdbServices.Dtos;
using ImdbServices.Interfaces;
using System;

namespace ImdbServices.Services
{
    public interface IMovieService : IImdbCrudService<Movie>
    {
        MovieDetailsDto ObterDatails(Guid id);
    }
}