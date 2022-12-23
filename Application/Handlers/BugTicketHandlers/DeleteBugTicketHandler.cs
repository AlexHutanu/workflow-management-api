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
    public class DeleteBugTicketHandler : IRequestHandler<DeleteBugTicket, BugTicket>
    {

        private readonly IUnitOfWork _unitOfWork;
        public DeleteBugTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BugTicket> Handle(DeleteBugTicket request, CancellationToken cancellationToken)
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
