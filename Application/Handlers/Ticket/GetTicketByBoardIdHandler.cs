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
    public class GetTicketByBoardIdHandler : IRequestHandler<GetTicketByBoardId, IEnumerable<Infrastructure.Entities.TicketEntity>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetTicketByBoardIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        public async Task<IEnumerable<TicketEntity>> Handle(GetTicketByBoardId request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Tickets.GetByBoardId(request.BoardId);
        }
    }
}
