using Domain.Entities;
using MediatR;

namespace Application.Commands
{

    public class CreateBoardCommand : IRequest<Board>
    {
        public Board NewBoard { get; set; }
    }
}