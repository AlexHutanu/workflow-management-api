using Infrastructure.Entities;
using Infrastructure.Enums;
using MediatR;

namespace Application.Commands
{

    public class CreateTicket : IRequest<TicketEntity>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Assignee { get; set; }

        public string? Reporter { get; set; }

        public string? Description { get; set; }

        public double Deadline { get; set; }

        public TicketStatus Status { get; set; }

        public Guid BoardId { get; set; }

        public Guid UserId { get; set; }
    }
}