using Application.Commands;
using Infrastructure.Entities;
using MediatR;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Application.Handlers.Board
{

    public class CreateBoardHandler : IRequestHandler<CreateBoard, Infrastructure.Entities.BoardEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateBoardHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Infrastructure.Entities.BoardEntity> Handle(CreateBoard request, CancellationToken cancellationToken)
        {
            var board = new Infrastructure.Entities.BoardEntity
            {
                Id = request.Id,
                Name = request.Name,
                Owner = request.Owner,
                Description = request.Description,
                NoOfTickets = request.NoOfTickets,
            };

            await _unitOfWork.Boards.Add(board);
            await _unitOfWork.CompleteAsync();

            return board;
        }
    }
}