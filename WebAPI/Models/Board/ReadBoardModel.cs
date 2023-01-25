using Infrastructure.Entities;

namespace WebAPI.Models.Board
{
    public class ReadBoardModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Guid Owner { get; set; }

        public string? Description { get; set; }

        public int NoOfTickets { get; set; }

        public Guid UserId { get; set; }

        public ICollection<Infrastructure.Entities.TicketEntity> BugTickets { get; set; }
    }
}

