using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkflowManagement.Data;

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
            return await _context.BugTicket.FirstAsync(bugTicket => bugTicket.Name == request.Name,
                cancellationToken: cancellationToken);
        }
    }
}