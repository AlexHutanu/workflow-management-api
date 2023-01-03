using AutoMapper;
using Infrastructure.Entities;
using WebAPI.Models.ActivityDtos;

namespace WebAPI.Profiles
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<ActivityEntity, ReadActivityModel>();
            CreateMap<WriteActivityModel, ActivityEntity>();
        }
    }
}
