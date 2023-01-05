using Infrastructure.Entities;

namespace WebAPI.Models.BugTicket
{
    public class WriteTicketModel
    {
        public string? Name { get; set; }

        public string? Asignee { get; set; }

        public string? Description { get; set; }

        public double Deadline { get; set; }

        public string? Status { get; set; }

        public string? StepsToReproduce { get; set; }

        public string? ExpectedResult { get; set; }

        public string? ActualResult { get; set; }

        public TicketType TicketType { get; set; }

        public Guid BoardId { get; set; }
    }
}

