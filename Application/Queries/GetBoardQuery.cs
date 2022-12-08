using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetBoardQuery : IRequest<Board>
    {
        public Guid Id { get; }

        public GetBoardQuery(Guid id)
        {
            Id = id;
        }
    }
}