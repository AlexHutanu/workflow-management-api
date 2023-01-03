using Application.Queries;
using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.BugTicket
{
    public class GetBugTicketByBoardIdHandler : IRequestHandler<GetBugTicketByBoardId, IEnumerable<Infrastructure.Entities.BugTicketEntity>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetBugTicketByBoardIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        public async Task<IEnumerable<BugTicketEntity>> Handle(GetBugTicketByBoardId request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BugTickets.GetByBoardId(request.BoardId);
        }
    }
}
