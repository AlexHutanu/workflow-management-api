using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Column("TimeCreated", TypeName = "varchar(200)")]
        public DateTime TimeCreated { get; set; }
    }
}
