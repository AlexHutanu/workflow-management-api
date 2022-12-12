﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class Board : BaseEntity
{ 

    [Column("Name", TypeName = "varchar(200)")]
    public string? Name { get; set; }
    
    [Column("OwnerName", TypeName = "varchar(200)")]
    public string? Owner { get; set; }

    [Column("Description", TypeName = "varchar(200)")]
    public string? Description { get; set; }

    [Column("NoOfTickets", TypeName = "varchar(200)")]
    public int NoOfTickets { get; set; }
}