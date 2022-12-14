using Infrastructure.Entities;
using MediatR;

namespace Application.Commands
{

    public class CreateTicket : IRequest<TicketEntity>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Asignee { get; set; }

        public string? Reporter { get; set; }

        public string? Description { get; set; }

        public double Deadline { get; set; }

        public string? Status { get; set; }

        public TicketType TicketType { get; set; }

        public Guid BoardForeignKey { get; set; }
    }
}