using AutoMapper;
using Infrastructure.Entities;
using WebAPI.Models.BugTicket;

namespace WebAPI.Profiles
{
    public class BugTicketProfile : Profile
    {
        public BugTicketProfile() {
            CreateMap<BugTicket, ReadBugTicketModel>();
            CreateMap<WriteBugTicketModel, BugTicket>();
        }   
    }
}
