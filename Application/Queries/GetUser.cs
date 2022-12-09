using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetUser : IRequest<User>
    {
        public Guid Id { get; }

        public GetUser(Guid id)
        {
            Id = id;
        }
    }
}