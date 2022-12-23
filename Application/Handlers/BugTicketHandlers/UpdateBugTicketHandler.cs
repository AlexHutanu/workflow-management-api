using Application.Commands;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.BugTicketHandlers
{
    public class UpdateBugTicketHandler : IRequestHandler<UpdateBugTicket, BugTicket>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBugTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BugTicket> Handle(UpdateBugTicket request, CancellationToken cancellationToken)
        {
            var toUpdate = new BugTicket();

            toUpdate.Id = request.BugTicketId;
            toUpdate.Name = request.Name;
            toUpdate.Description = request.Description;
            toUpdate.Asignee = request.Asignee;
            toUpdate.StepsToReproduce = request.StepsToReproduce;
            toUpdate.Deadline = request.Deadline;
            toUpdate.ActualResult = request.ActualResult;
            toUpdate.ExpectedResult = request.ExpectedResult;
            toUpdate.Status = request.Status;


            await _unitOfWork.BugTickets.Update(toUpdate);
            await _unitOfWork.CompleteAsync();

            return toUpdate;
        }
    }
}
