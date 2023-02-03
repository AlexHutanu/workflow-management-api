using Domain.Entities;
using Domain.Enums;

namespace WebAPI.Models.BugTicket
{
    public class WriteTicketModel
    {
        public string? Name { get; set; }

        public Guid Assignee { get; set; }

        public string? Description { get; set; }

        public string? Reporter { get; set; }

        public double Deadline { get; set; }

        public TicketStatus Status { get; set; }

        public TicketType Type { get; set; }

        public TicketLabel Label { get; set; }

        public Guid BoardId { get; set; }

        public Guid UserId { get; set; }
    }
}

