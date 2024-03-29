﻿using Application.Commands;
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
    public class UpdateTicketHandler : IRequestHandler<UpdateTicket, TicketEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TicketEntity> Handle(UpdateTicket request, CancellationToken cancellationToken)
        {
            var toUpdate = new TicketEntity();

            toUpdate.Id = request.TicketId;
            toUpdate.Name = request.Name;
            toUpdate.Description = request.Description;
            toUpdate.Assignee = request.Assignee;
            toUpdate.Deadline = request.Deadline;
            toUpdate.Status = request.Status;
            toUpdate.BoardId = request.BoardId;
            toUpdate.UserId = request.UserId;
            toUpdate.Type = request.Type;
            toUpdate.Label = request.Label;



            await _unitOfWork.Tickets.Update(toUpdate);
            await _unitOfWork.CompleteAsync();

            return toUpdate;
        }
    }
}
