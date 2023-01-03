using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Handlers.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, Infrastructure.Entities.UserEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Infrastructure.Entities.UserEntity> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetById(request.UserId);

            if (user == null)
                return null;

            await _unitOfWork.Users.Delete(request.UserId);

            await _unitOfWork.CompleteAsync();

            return user;

        }
    }
}
