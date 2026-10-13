using AutoMapper;
using CQRS_DEMO.Models;
using CQRS_DEMO.DTOS;
namespace CQRS_DEMO.Mapping
{
    public class UserProfile : Profile

    {
        public UserProfile()
        {
            CreateMap<user, UserDto>().ReverseMap();
        }
    }
}
