using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetBugTicketQuery : IRequest<BugTicket>
    {
        public Guid Id { get; }

        public GetBugTicketQuery(Guid id)
        {
            Id = id;
        }
    }
}