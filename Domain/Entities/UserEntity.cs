using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {

        [Column("Name", TypeName = "varchar(200)")]
        public string? Name { get; set; }

        [Column("Email", TypeName = "varchar(200)")]
        public string? Email { get; set; }

        [Column("Password", TypeName = "varchar(200)")]
        public string? Password { get; set; }

        public ICollection<BoardEntity>? Boards { get; set; }
        public ICollection<TicketEntity>? Tickets { get; set; }
    }
}
