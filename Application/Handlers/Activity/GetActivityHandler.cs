using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Application.Handlers.Activity
{

    public class GetActivityHandler : IRequestHandler<GetActivity, ActivityEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetActivityHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActivityEntity> Handle(GetActivity request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Activities.GetById(request.Id);
        }
    }
}