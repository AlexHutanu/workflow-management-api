using Infrastructure.Entities;
using MediatR;
namespace Application.Commands
{

    public class CreateUserCommand : IRequest<User>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}