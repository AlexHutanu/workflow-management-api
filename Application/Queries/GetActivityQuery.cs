using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetActivityQuery : IRequest<Activity>
    {
        public Guid Id { get; }

        public GetActivityQuery(Guid id)
        {
            Id = id;
        }
    }
}