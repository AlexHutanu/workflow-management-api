using Application.Commands;
using Infrastructure.Entities;
using Infrastructure.Interfaces.IConfiguration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.UserHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var toUpdate = new User();

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
