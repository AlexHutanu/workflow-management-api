using AutoMapper;
using Infrastructure.Entities;
using WebAPI.Dtos.ActivityDtos;

namespace WebAPI.Profiles
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activity, ActivityGetDto>();
            CreateMap<ActivityPostPutDto, Activity>();
        }
    }
}
