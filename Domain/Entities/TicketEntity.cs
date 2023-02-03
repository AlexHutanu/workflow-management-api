using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;


public class TicketEntity : BaseEntity
{

    [Column("Name", TypeName = "varchar(200)")]
    public string? Name { get; set; }

    [Column("Asignee", TypeName = "varchar(200)")]
    public Guid Assignee { get; set; }

    [Column("Reporter", TypeName = "varchar(200)")]
    public string? Reporter { get; set; }

    [Column("Description", TypeName = "varchar(200)")]
    public string? Description { get; set; }

    [Column("Deadline", TypeName = "varchar(200)")]
    public double Deadline { get; set; }

    [Column("Status", TypeName = "int")]
    public TicketStatus Status { get; set; }

    public TicketType Type { get; set; }

    public TicketLabel Label { get; set; }

    public BoardEntity Board { get; set; }

    public Guid BoardId { get; set; }

    public UserEntity User { get; set; }

    public Guid UserId  { get; set; }
    

}



