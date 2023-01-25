using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Application.Handlers.Ticket
{

    public class GetTicketHandler : IRequestHandler<GetTicket, Infrastructure.Entities.TicketEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Infrastructure.Entities.TicketEntity> Handle(GetTicket request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Tickets.GetById(request.Id);
        }
    }
}