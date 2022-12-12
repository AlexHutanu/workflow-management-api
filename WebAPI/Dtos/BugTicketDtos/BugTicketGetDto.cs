namespace WebAPI.Dtos.BugTicketDtos
{
    public class BugTicketGetDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Asignee { get; set; }

        public string? Reporter { get; set; }

        public string? Description { get; set; }

        public double Deadline { get; set; }

        public string? Status { get; set; }

        public string? StepsToReproduce { get; set; }

        public string? ExpectedResult { get; set; }

        public string? ActualResult { get; set; }
    }
}
