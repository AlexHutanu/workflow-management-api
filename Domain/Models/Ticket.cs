using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;


public abstract class Ticket
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Asignee { get; set; }

    public string? Reporter { get; set; }

    public string? Description { get; set; }

    public double Deadline { get; set; }

    public string? Status { get; set; }
}



