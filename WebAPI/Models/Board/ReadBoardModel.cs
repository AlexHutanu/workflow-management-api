using Infrastructure.Entities;

namespace WebAPI.Models.Board
{
    public class ReadBoardModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Owner { get; set; }

        public string? Description { get; set; }

        public int NoOfTickets { get; set; }

        public ICollection<Infrastructure.Entities.BugTicket> BugTickets { get; set; }
    }
}

