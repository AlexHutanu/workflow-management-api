using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Queries;
using Domain.Entities;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Handlers.Activity
{
    public class GetAllActivitiesHandler : IRequestHandler<GetAllActivities, IEnumerable<ActivityEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllActivitiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ActivityEntity>> Handle(GetAllActivities request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Activities.GetAll();
        }
    }
}
