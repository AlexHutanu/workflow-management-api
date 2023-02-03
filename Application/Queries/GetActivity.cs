
using Domain.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetActivity : IRequest<ActivityEntity>
    {
        public Guid Id { get; }

        public GetActivity(Guid id)
        {
            Id = id;
        }
    }
}