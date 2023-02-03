using Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Handlers.User
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<UserEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserEntity>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Users.GetAll();
        }
    }
}
