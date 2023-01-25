using Application.Queries;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Ticket
{
    public class GetTicketByUserIdHandler : IRequestHandler<GetTicketByUserId, IEnumerable<TicketEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTicketByUserIdHandler(IUnitOfWork unitOfWork) {

            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TicketEntity>> Handle(GetTicketByUserId request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Tickets.GetByUserId(request.UserId);
        }


    }
}
