using Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Application.Handlers.Ticket
{
    public class GetAllTicketsHandler : IRequestHandler<GetAllTickets, IEnumerable<Infrastructure.Entities.TicketEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTicketsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Infrastructure.Entities.TicketEntity>> Handle(GetAllTickets request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Tickets.GetAll();
        }
    }
}
