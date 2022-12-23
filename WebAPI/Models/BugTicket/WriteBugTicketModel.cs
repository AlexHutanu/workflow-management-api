namespace WebAPI.Models.BugTicket
{
    public class WriteBugTicketModel
    {
        public string? Name { get; set; }

        public string? Asignee { get; set; }

        public string? Description { get; set; }

        public double Deadline { get; set; }

        public string? Status { get; set; }

        public string? StepsToReproduce { get; set; }

        public string? ExpectedResult { get; set; }

        public string? ActualResult { get; set; }

        public Guid BoardId { get; set; }
    }
}

