using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Application.Handlers.BugTicketHandlers
{

    public class GetBugTicketQueryHandler : IRequestHandler<GetBugTicketQuery, BugTicket>
    {

        private readonly ApplicationDbContext _context;

        public GetBugTicketQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BugTicket> Handle(GetBugTicketQuery request, CancellationToken cancellationToken)
        {
            return await _context.BugTickets.FirstAsync(bugTicket => bugTicket.Id == request.Id,
                cancellationToken: cancellationToken);
        }
    }
}