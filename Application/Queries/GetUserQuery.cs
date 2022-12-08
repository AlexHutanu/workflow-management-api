using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetUserQuery : IRequest<User>
    {
        public Guid Id { get; }

        public GetUserQuery(Guid id)
        {
            Id = id;
        }
    }
}