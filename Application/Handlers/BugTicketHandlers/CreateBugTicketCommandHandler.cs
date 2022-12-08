using Application.Commands;
using Infrastructure.Entities;
using MediatR;
using Infrastructure.Data;
using Infrastructure.Interfaces.IConfiguration;

namespace Application.Handlers.BugTicketHandlers
{

    public class CreateBugTicketCommandHandler : IRequestHandler<CreateBugTicketCommand, BugTicket>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateBugTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BugTicket> Handle(CreateBugTicketCommand request, CancellationToken cancellationToken)
        {

            var bugTicket = new BugTicket
            {
                Id = request.Id,
                Name = request.Name,
                Asignee = request.Asignee,
                Reporter = request.Reporter,
                Description = request.Description,
                Deadline = request.Deadline,
                Status = request.Status,
                StepsToReproduce = request.StepsToReproduce,
                ExpectedResult = request.ExpectedResult,
                ActualResult = request.ActualResult,
            };

            await _unitOfWork.BugTickets.Add(bugTicket);
            await _unitOfWork.CompleteAsync();

            return bugTicket;
        }
    }
}