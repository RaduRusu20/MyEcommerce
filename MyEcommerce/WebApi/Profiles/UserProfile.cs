using AutoMapper;
using Domain.Users;
using WebApi.DTOs;

namespace WebApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
