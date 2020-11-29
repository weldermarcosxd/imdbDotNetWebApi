using AutoMapper;
using ImbdDomain.Models;
using ImdbServices.Dtos;
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
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Staff.Select(x => x.Name).ToArray()))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Votes.Average(x => x.Score)));
        }
    }
}
