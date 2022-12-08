using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class BugTicket : Ticket
{
    public string? StepsToReproduce { get; set; }

    public string? ExpectedResult { get; set; }

    public string? ActualResult { get; set; }
    
}