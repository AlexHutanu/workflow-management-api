using Application.Commands;
using Domain.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Activity
{
    public class UpdateActivityHandler : IRequestHandler<UpdateActivity, ActivityEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateActivityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActivityEntity> Handle(UpdateActivity request, CancellationToken cancellationToken)
        {
            var updatedActivity = new ActivityEntity();

            updatedActivity.Id = request.ActivityId;
            updatedActivity.Name = request.Name;
            updatedActivity.Description = request.Description;

            await _unitOfWork.Activities.Update(updatedActivity);
            await _unitOfWork.CompleteAsync();

            return updatedActivity;
        }
    }
}
