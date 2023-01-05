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
    public class UpdateTicketHandler : IRequestHandler<UpdateTicket, Infrastructure.Entities.TicketEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Infrastructure.Entities.TicketEntity> Handle(UpdateTicket request, CancellationToken cancellationToken)
        {
            var toUpdate = new Infrastructure.Entities.TicketEntity();

            toUpdate.Id = request.TicketId;
            toUpdate.Name = request.Name;
            toUpdate.Description = request.Description;
            toUpdate.Asignee = request.Asignee;
            toUpdate.Deadline = request.Deadline;
            toUpdate.Status = request.Status;


            await _unitOfWork.Tickets.Update(toUpdate);
            await _unitOfWork.CompleteAsync();

            return toUpdate;
        }
    }
}
