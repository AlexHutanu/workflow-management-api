using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;


public abstract class Ticket
{
    [Key]
    public Guid Id { get; set; }

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
}



