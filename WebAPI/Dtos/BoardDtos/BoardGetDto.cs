using Infrastructure.Entities;

namespace WebAPI.Dtos.BoardDtos
{
    public class BoardGetDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Owner { get; set; }

        public string? Description { get; set; }

        public int NoOfTickets { get; set; }

        public ICollection<BugTicket> BugTickets { get; set; }
    }
}

