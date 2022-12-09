using Application.Queries;
using Infrastructure.Interfaces.IConfiguration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Application.Handlers.UserHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Users.GetAll();
        }
    }
}
