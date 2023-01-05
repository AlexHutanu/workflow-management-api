using AutoMapper;
using Infrastructure.Entities;
using WebAPI.Models.BugTicket;

namespace WebAPI.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile() {
            CreateMap<TicketEntity, ReadTicketModel>();
            CreateMap<WriteTicketModel, TicketEntity>();
        }   
    }
}
