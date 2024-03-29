using Domain.Entities;
using MediatR;
namespace Application.Commands
{

    public class CreateUser : IRequest<UserEntity>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}