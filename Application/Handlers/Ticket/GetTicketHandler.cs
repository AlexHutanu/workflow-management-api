using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Application.Handlers.Ticket
{

    public class GetTicketHandler : IRequestHandler<GetTicket, TicketEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TicketEntity> Handle(GetTicket request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Tickets.GetById(request.Id);
        }
    }
}