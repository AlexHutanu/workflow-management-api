using Infrastructure.Entities;
using Infrastructure.Enums;
using MediatR;

namespace Application.Commands
{
    public class UpdateTicket : IRequest<TicketEntity>
    {
        public Guid TicketId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid Assignee { get; set; }
        public TicketStatus Status { get; set; }
        public TicketType Type { get; set; }

        public TicketLabel Label { get; set; }
        public double Deadline { get; set; }
        public Guid BoardId { get; set; }

        public Guid UserId { get; set; }
    }
}
