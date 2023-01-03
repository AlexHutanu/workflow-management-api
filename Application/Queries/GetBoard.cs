using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetBoard : IRequest<BoardEntity>
    {
        public Guid Id { get; }

        public GetBoard(Guid id)
        {
            Id = id;
        }
    }
}