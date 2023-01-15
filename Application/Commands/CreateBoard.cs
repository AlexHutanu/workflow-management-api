using Infrastructure.Entities;
using MediatR;
namespace Application.Commands
{

    public class CreateBoard : IRequest<BoardEntity>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Owner { get; set; }

        public string? Description { get; set; }

        public int NoOfTickets { get; set; }

        public Guid UserId { get; set; }
    
        public bool IsPrimary { get; set; }
    }
}
