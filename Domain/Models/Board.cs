using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Board
{
    public int Id { get; set; }

    public string? Name { get; set; }
   
    public string? Owner { get; set; }

    public string? Description { get; set; }

    public int NoOfTickets { get; set; }
}