using Infrastructure.Entities;
using MediatR;

namespace Application.Commands
{
    public class UpdateTicket : IRequest<TicketEntity>
    {
        public Guid TicketId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Asignee { get; set; }
        public string? Status { get; set; }
        public double Deadline { get; set; }
        public Guid BoardId { get; set; }
    }
}
