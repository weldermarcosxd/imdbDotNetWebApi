using AutoMapper;
using ImbdDomain.Models;
using ImdbServices.Dtos;

namespace ImdbServices.Mappers
{
    public class UserMappers : Profile
    {
        public UserMappers()
        {
            Dtos();
        }

        private void Dtos()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
