using Application.Commands;
using Domain.Entities;
using MediatR;
using WorkflowManagement.Data;

namespace Application.Handlers.UserHandler
{

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {

        private readonly ApplicationDbContext _context;

        public CreateUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _context.User.Add(request.NewUser);
            await _context.SaveChangesAsync(cancellationToken);

            return request.NewUser;
        }
    }
}