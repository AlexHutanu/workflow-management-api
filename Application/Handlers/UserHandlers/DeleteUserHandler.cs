using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Infrastructure.Entities;
using Infrastructure.Interfaces.IConfiguration;
using MediatR;

namespace Application.Handlers.UserHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, User>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(DeleteUser request, CancellationToken cancellationToken)
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
