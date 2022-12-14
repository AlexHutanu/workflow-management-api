using AutoMapper;
using Infrastructure.Entities;
using System.Security.Cryptography.Xml;
using WebAPI.Models.User;

namespace WebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {

            CreateMap<UserEntity, ReadUserModel>();
            CreateMap<WriteUserModel, UserEntity>();
        }
    }
}
