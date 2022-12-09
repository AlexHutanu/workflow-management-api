using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetActivity : IRequest<Activity>
    {
        public Guid Id { get; }

        public GetActivity(Guid id)
        {
            Id = id;
        }
    }
}