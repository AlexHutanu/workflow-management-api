using Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Application.Handlers.BugTicket
{
    public class GetAllBugTicketsHandler : IRequestHandler<GetAllBugTickets, IEnumerable<Infrastructure.Entities.BugTicketEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBugTicketsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Infrastructure.Entities.BugTicketEntity>> Handle(GetAllBugTickets request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BugTickets.GetAll();
        }
    }
}
