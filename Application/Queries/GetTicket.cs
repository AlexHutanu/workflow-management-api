using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetTicket : IRequest<TicketEntity>
    {
        public Guid Id { get; }

        public GetTicket(Guid id)
        {
            Id = id;
        }
    }
}