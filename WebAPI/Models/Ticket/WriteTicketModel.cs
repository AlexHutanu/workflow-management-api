using Infrastructure.Entities;
using Infrastructure.Enums;

namespace WebAPI.Models.BugTicket
{
    public class WriteTicketModel
    {
        public string? Name { get; set; }

        public string? Asignee { get; set; }

        public string? Description { get; set; }

        public double Deadline { get; set; }

        public TicketStatus Status { get; set; }

        public Guid BoardId { get; set; }

        public Guid UserId { get; set; }
    }
}

