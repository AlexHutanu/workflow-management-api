using AutoMapper;
using Infrastructure.Entities;
using WebAPI.Models.BugTicket;

namespace WebAPI.Profiles
{
    public class BugTicketProfile : Profile
    {
        public BugTicketProfile() {
            CreateMap<BugTicketEntity, ReadBugTicketModel>();
            CreateMap<WriteBugTicketModel, BugTicketEntity>();
        }   
    }
}
