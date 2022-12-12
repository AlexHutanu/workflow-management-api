using AutoMapper;
using Infrastructure.Entities;
using System.Security.Cryptography.Xml;
using WebAPI.Dtos.UserDtos;

namespace WebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {

            CreateMap<User, UserGetDto>();
            CreateMap<UserPostPutDto, User>();
        }
    }
}
