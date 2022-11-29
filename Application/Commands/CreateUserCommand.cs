using Domain.Entities;
using MediatR;

namespace Application.Commands
{


    public class CreateUserCommand : IRequest<User>
    {
        public User NewUser { get; set; }
    }
}