using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetBugTicket : IRequest<BugTicket>
    {
        public Guid Id { get; }

        public GetBugTicket(Guid id)
        {
            Id = id;
        }
    }
}