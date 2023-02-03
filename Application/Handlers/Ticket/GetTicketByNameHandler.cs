using Application.Queries;
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
    public class GetTicketByNameHandler : IRequestHandler<GetTicketByName, IEnumerable<TicketEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTicketByNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TicketEntity>> Handle(GetTicketByName request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Tickets.GetByName(request.Name);
        }
    }
}
