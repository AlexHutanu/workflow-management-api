using Domain.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetBoard : IRequest<BoardEntity>
    {
        public Guid Id { get; }
        public string Name { get; }

        public GetBoard(string name)
        {
            Name = name;
        }

        public GetBoard(Guid id)
        {
            Id = id;
        }
    }
}