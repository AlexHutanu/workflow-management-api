using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Commands
{

    public class CreateTicket : IRequest<TicketEntity>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Guid Assignee { get; set; }

        public string? Reporter { get; set; }

        public string? Description { get; set; }

        public double Deadline { get; set; }

        public TicketStatus Status { get; set; }

        public TicketType Type { get; set; }

        public TicketLabel Label { get; set; }

        public Guid BoardId { get; set; }

        public Guid UserId { get; set; }
    }
}