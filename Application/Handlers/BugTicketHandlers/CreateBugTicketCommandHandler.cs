using Application.Commands;
using Domain.Entities;
using MediatR;
using WorkflowManagement.Data;

namespace Application.Handlers.BugTicketHandlers
{

    public class CreateBugTicketCommandHandler : IRequestHandler<CreateBugTicketCommand, BugTicket>
    {

        private readonly ApplicationDbContext _context;

        public CreateBugTicketCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BugTicket> Handle(CreateBugTicketCommand request, CancellationToken cancellationToken)
        {
            _context.BugTicket.Add(request.NewBugTicket);
            await _context.SaveChangesAsync(cancellationToken);

            return request.NewBugTicket;
        }
    }
}