using Infrastructure.Entities;
using Infrastructure.Enums;

namespace WebAPI.Models.BugTicket
{
    public class ReadTicketModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Asignee { get; set; }

        public string? Reporter { get; set; }

        public string? Description { get; set; }

        public double Deadline { get; set; }

        public TicketStatus Status { get; set; }
    }
}
