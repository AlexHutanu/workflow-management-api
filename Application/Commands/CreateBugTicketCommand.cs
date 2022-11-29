using Domain.Entities;
using MediatR;

namespace Application.Commands
{

    public class CreateBugTicketCommand : IRequest<BugTicket>
    {
        public BugTicket NewBugTicket { get; set; }
    }
}