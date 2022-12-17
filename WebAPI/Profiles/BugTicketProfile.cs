using AutoMapper;
using Infrastructure.Entities;
using WebAPI.Dtos.BugTicketDtos;

namespace WebAPI.Profiles
{
    public class BugTicketProfile : Profile
    {
        public BugTicketProfile() {
            CreateMap<BugTicket, BugTicketGetDto>();
            CreateMap<BugTicketPostPutDto, BugTicket>();
        }   
    }
}
