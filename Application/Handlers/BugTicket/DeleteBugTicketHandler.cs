using Application.Commands;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.BugTicket
{
    public class DeleteBugTicketHandler : IRequestHandler<DeleteBugTicket, Infrastructure.Entities.BugTicketEntity>
    {

        private readonly IUnitOfWork _unitOfWork;
        public DeleteBugTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Infrastructure.Entities.BugTicketEntity> Handle(DeleteBugTicket request, CancellationToken cancellationToken)
        {
            var bugTicket = await _unitOfWork.BugTickets.GetById(request.BugTicketId);

            if (bugTicket == null)
                return null;

            await _unitOfWork.Activities.Delete(request.BugTicketId);

            await _unitOfWork.CompleteAsync();

            return bugTicket;
        }
    }
}
