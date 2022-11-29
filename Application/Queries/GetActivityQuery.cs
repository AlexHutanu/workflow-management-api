using Domain.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetActivityQuery : IRequest<Activity>
    {
        public string? Name { get; }

        public GetActivityQuery(string name)
        {
            Name = name;
        }
    }
}