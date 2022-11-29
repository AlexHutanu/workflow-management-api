using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetBugTicketQuery : IRequest<BugTicket>
    {
        public string? Name { get; }

        public GetBugTicketQuery(string name)
        {
            Name = name;
        }
    }
}