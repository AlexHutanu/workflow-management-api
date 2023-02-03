using Application.Commands;
using Domain.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.User
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, UserEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserEntity> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var toUpdate = new UserEntity();

            toUpdate.Id = request.UserId;
            toUpdate.Name = request.Name;
            toUpdate.Email = request.Email;
            toUpdate.Password = request.Password;

            await _unitOfWork.Users.Update(toUpdate);
            await _unitOfWork.CompleteAsync();

            return toUpdate;
        }
    }
}
