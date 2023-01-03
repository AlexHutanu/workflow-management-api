using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetBugTicket : IRequest<BugTicketEntity>
    {
        public Guid Id { get; }

        public GetBugTicket(Guid id)
        {
            Id = id;
        }
    }
}