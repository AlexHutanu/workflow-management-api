using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{

    public class GetUserQuery : IRequest<User>
    {
        public string? Name { get; set; }

        public GetUserQuery(string name)
        {
            Name = name;
        }
    }
}