using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Queries;
using Infrastructure.Entities;
using Infrastructure.Interfaces.IConfiguration;
using MediatR;

namespace Application.Handlers.ActivityHandlers
{
    public class GetAllActivitiesHandler : IRequestHandler<GetAllActivities, IEnumerable<Activity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllActivitiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Activity>> Handle(GetAllActivities request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Activities.GetAll();
        }
    }
}
