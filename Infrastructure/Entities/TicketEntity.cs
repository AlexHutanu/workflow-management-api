using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;


public class TicketEntity : BaseEntity
{

    [Column("name", TypeName = "varchar(200)")]
    public string? Name { get; set; }

    [Column("asignee", TypeName = "varchar(200)")]
    public string? Asignee { get; set; }

    [Column("reporter", TypeName = "varchar(200)")]
    public string? Reporter { get; set; }

    [Column("description", TypeName = "varchar(200)")]
    public string? Description { get; set; }

    [Column("deadline", TypeName = "varchar(200)")]
    public double Deadline { get; set; }

    [Column("status", TypeName = "varchar(200)")]
    public string? Status { get; set; }

    public BoardEntity Board { get; set; }

    public Guid BoardForeignKey { get; set; }
    

}



