using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Column("TimeCreated", TypeName = "varchar(200)")]
        public DateTime TimeCreated { get; set; }
    }
}
