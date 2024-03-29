using Application.Commands;
using Domain.Entities;
using MediatR;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Application.Handlers.Board
{

    public class CreateBoardHandler : IRequestHandler<CreateBoard, BoardEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateBoardHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BoardEntity> Handle(CreateBoard request, CancellationToken cancellationToken)
        {
            var board = new BoardEntity
            {
                Id = request.Id,
                Name = request.Name,
                Owner = request.Owner,
                Description = request.Description,
                NoOfTickets = request.NoOfTickets,
                UserId = request.UserId,
            };

            await _unitOfWork.Boards.Add(board);
            await _unitOfWork.CompleteAsync();

            return board;
        }
    }
}