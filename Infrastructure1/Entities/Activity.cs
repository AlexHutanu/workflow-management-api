using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class Activity
{
    [Key]
    public Guid Id { get; set; }

    [Column("Name", TypeName = "varchar(200)")]
    public string? Name { get; set; }

    [Column("Description", TypeName = "varchar(200)")]
    public string? Description { get; set; }

    [Column("Owner", TypeName = "varchar(200)")]
    public string? Owner { get; set; }

    [Column("TimeCreated", TypeName = "varchar(200)")]
    public DateTime TimeCreated { get; set; }
}