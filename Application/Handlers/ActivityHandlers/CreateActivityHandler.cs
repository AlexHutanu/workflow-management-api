using Application.Commands;
using Infrastructure.Entities;
using MediatR;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Application.Handlers.ActivityHandlers
{


    public class CreateActivityHandler : IRequestHandler<CreateActivity, Activity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateActivityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Activity> Handle(CreateActivity request, CancellationToken cancellationToken)
        {

            var activity = new Activity
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Owner = request.Owner,
                TimeCreated = request.TimeCreated,
            };

            await _unitOfWork.Activities.Add(activity);
            await _unitOfWork.CompleteAsync();

            return activity;
        }
    }
}