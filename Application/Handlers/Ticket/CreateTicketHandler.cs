using Application.Commands;
using Infrastructure.Entities;
using MediatR;
using Infrastructure.Interfaces;

namespace Application.Handlers.BugTicket
{

    public class CreateTicketHandler : IRequestHandler<CreateTicket, Infrastructure.Entities.TicketEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Infrastructure.Entities.TicketEntity> Handle(CreateTicket request, CancellationToken cancellationToken)
        {

            var ticket = new Infrastructure.Entities.TicketEntity
            {
                Id = request.Id,
                Name = request.Name,
                Asignee = request.Asignee,
                Reporter = request.Reporter,
                Description = request.Description,
                Deadline = request.Deadline,
                Status = request.Status,
                BoardId = request.BoardId,
                UserId = request.UserId
            };

            await _unitOfWork.Tickets.Add(ticket);
            await _unitOfWork.CompleteAsync();

            return ticket;
        }
    }
}