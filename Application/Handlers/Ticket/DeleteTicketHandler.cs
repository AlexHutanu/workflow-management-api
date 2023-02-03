using Application.Commands;
using Domain.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Ticket
{
    public class DeleteTicketHandler : IRequestHandler<DeleteTicket, TicketEntity>
    {

        private readonly IUnitOfWork _unitOfWork;
        public DeleteTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TicketEntity> Handle(DeleteTicket request, CancellationToken cancellationToken)
        {
            var ticket = await _unitOfWork.Tickets.GetById(request.TicketId);

            if (ticket == null)
                return null;

            await _unitOfWork.Activities.Delete(request.TicketId);

            await _unitOfWork.CompleteAsync();

            return ticket;
        }
    }
}
