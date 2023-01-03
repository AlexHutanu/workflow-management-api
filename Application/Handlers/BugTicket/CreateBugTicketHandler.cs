using Application.Commands;
using Infrastructure.Entities;
using MediatR;
using Infrastructure.Interfaces;

namespace Application.Handlers.BugTicket
{

    public class CreateBugTicketHandler : IRequestHandler<CreateBugTicket, Infrastructure.Entities.BugTicketEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateBugTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Infrastructure.Entities.BugTicketEntity> Handle(CreateBugTicket request, CancellationToken cancellationToken)
        {

            var bugTicket = new Infrastructure.Entities.BugTicketEntity
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
                BoardForeignKey = request.BoardForeignKey
            };

            await _unitOfWork.BugTickets.Add(bugTicket);
            await _unitOfWork.CompleteAsync();

            return bugTicket;
        }
    }
}