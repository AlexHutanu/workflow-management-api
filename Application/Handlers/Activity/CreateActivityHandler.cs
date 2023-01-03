
using Infrastructure.Entities;
using MediatR;
using Infrastructure.Interfaces;

namespace Application.Handlers.Activity
{


    public class CreateActivityHandler : IRequestHandler<Commands.Activity, Infrastructure.Entities.ActivityEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateActivityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActivityEntity> Handle(Commands.Activity request, CancellationToken cancellationToken)
        {

            var activity = new ActivityEntity
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