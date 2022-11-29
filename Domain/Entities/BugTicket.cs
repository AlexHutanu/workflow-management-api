using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class BugTicket : Ticket
{
    [Column("steps_to_reproduce", TypeName = "varchar(200)")]
    public string? StepsToReproduce { get; set; }

    [Column("expected_result", TypeName = "varchar(200)")]
    public string? ExpectedResult { get; set; }

    [Column("actual_result", TypeName = "varchar(200)")]
    public string? ActualResult { get; set; }
    
}