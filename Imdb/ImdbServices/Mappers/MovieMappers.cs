using AutoMapper;
using ImbdDomain.Models;
using ImdbServices.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ImdbServices.Mappers
{
    public class MovieMappers : Profile
    {
        public MovieMappers()
        {
            Dtos();
        }

        private void Dtos()
        {
            CreateMap<MovieDetailsDto, Movie>().ReverseMap()
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Staff.Any() ? src.Staff.Select(x => x.Name).ToArray() : new List<string>().ToArray()))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Votes.Any() ? src.Votes.Average(x => x.Score) : 0L));
        }
    }
}
