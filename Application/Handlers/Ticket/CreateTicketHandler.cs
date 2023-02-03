using Application.Commands;
using Domain.Entities;
using MediatR;
using Infrastructure.Interfaces;

namespace Application.Handlers.Ticket
{

    public class CreateTicketHandler : IRequestHandler<CreateTicket, TicketEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TicketEntity> Handle(CreateTicket request, CancellationToken cancellationToken)
        {

            var ticket = new TicketEntity
            {
                Id = request.Id,
                Name = request.Name,
                Assignee = request.Assignee,
                Reporter = request.Reporter,
                Description = request.Description,
                Deadline = request.Deadline,
                Status = request.Status,
                BoardId = request.BoardId,
                UserId = request.UserId,
                Type = request.Type,
                Label = request.Label
            };

            await _unitOfWork.Tickets.Add(ticket);
            await _unitOfWork.CompleteAsync();

            return ticket;
        }
    }
}