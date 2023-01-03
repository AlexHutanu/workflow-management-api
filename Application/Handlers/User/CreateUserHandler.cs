using Application.Commands;
using Infrastructure.Entities;
using MediatR;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Application.Handlers.User
{

    public class CreateUserHandler : IRequestHandler<CreateUser, Infrastructure.Entities.UserEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Infrastructure.Entities.UserEntity> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = new Infrastructure.Entities.UserEntity {
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