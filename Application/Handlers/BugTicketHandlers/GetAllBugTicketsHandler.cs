using Application.Queries;
using Infrastructure.Interfaces.IConfiguration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Application.Handlers.BugTicketHandlers
{
    public class GetAllBugTicketsHandler : IRequestHandler<GetAllBugTickets, IEnumerable<BugTicket>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBugTicketsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BugTicket>> Handle(GetAllBugTickets request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BugTickets.GetAll();
        }
    }
}
