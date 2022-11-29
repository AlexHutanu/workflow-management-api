﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Name", TypeName = "varchar(200)")]
        public string? Name { get; set; }

        [Column("Email", TypeName = "varchar(200)")]
        public string? Email { get; set; }

        [Column("Password", TypeName = "varchar(200)")]
        public string? Password { get; set; }
    }
}
