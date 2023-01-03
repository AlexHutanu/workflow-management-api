using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Queries;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Handlers.Activity
{
    public class GetAllActivitiesHandler : IRequestHandler<GetAllActivities, IEnumerable<Infrastructure.Entities.ActivityEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllActivitiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Infrastructure.Entities.ActivityEntity>> Handle(GetAllActivities request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Activities.GetAll();
        }
    }
}
