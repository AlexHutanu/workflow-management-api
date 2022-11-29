using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetBoardQuery : IRequest<Board>
    {
        public string? Name { get; }

        public GetBoardQuery(string name)
        {
            Name = name;
        }
    }
}