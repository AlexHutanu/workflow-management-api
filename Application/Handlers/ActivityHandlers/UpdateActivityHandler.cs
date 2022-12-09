using Application.Commands;
using Infrastructure.Entities;
using Infrastructure.Interfaces.IConfiguration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.ActivityHandlers
{
    public class UpdateActivityHandler : IRequestHandler<UpdateActivity, Activity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateActivityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Activity> Handle(UpdateActivity request, CancellationToken cancellationToken)
        {
            var toUpdate = new Activity();

            toUpdate.Id = request.ActivityId;
            toUpdate.Name = request.Name;
            toUpdate.Description = request.Description;

            await _unitOfWork.Activities.Update(toUpdate);
            await _unitOfWork.CompleteAsync();

            return toUpdate;
        }
    }
}
