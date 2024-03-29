﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class ActivityEntity : BaseEntity
{

    [Column("Name", TypeName = "varchar(200)")]
    public string? Name { get; set; }

    [Column("Description", TypeName = "varchar(200)")]
    public string? Description { get; set; }

    [Column("Owner", TypeName = "varchar(200)")]
    public string? Owner { get; set; }
}