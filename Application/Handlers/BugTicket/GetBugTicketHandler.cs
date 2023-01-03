using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Application.Handlers.BugTicket
{

    public class GetBugTicketHandler : IRequestHandler<GetBugTicket, Infrastructure.Entities.BugTicketEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetBugTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Infrastructure.Entities.BugTicketEntity> Handle(GetBugTicket request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BugTickets.GetById(request.Id);
        }
    }
}