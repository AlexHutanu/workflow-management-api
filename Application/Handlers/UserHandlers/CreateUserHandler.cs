using Application.Commands;
using Infrastructure.Entities;
using MediatR;
using Infrastructure.Data;
using Infrastructure.Interfaces.IConfiguration;

namespace Application.Handlers.UserHandlers
{

    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = new User {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
            };

            await _unitOfWork.Users.Add(user);
            await _unitOfWork.CompleteAsync();

            return user;
        }
    }
}