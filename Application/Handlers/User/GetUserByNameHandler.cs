using Application.Queries;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.User
{
    public class GetUserByNameHandler: IRequestHandler<GetUserByName, IEnumerable<UserEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserEntity>> Handle(GetUserByName request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Users.GetByName(request.Name);
        }
    }
}
