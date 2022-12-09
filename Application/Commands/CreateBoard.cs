using Infrastructure.Entities;
using MediatR;
namespace Application.Commands
{

    public class CreateBoard : IRequest<Board>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Owner { get; set; }

        public string? Description { get; set; }

        public int NoOfTickets { get; set; }
    }
}
