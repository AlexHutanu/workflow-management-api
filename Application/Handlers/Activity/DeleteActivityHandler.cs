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
    public class DeleteActivityHandler : IRequestHandler<DeleteActivity, ActivityEntity>
    {

        private readonly IUnitOfWork _unitOfWork;
        public DeleteActivityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActivityEntity> Handle(DeleteActivity request, CancellationToken cancellationToken)
        {
            var activity = await _unitOfWork.Activities.GetById(request.ActivityId);

            if (activity == null)
                return null;

            await _unitOfWork.Activities.Delete(request.ActivityId);

            await _unitOfWork.CompleteAsync();

            return activity;
        }
    }
}
