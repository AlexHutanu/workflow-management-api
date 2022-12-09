using Application.Commands;
using Infrastructure.Entities;
using MediatR;
using Infrastructure.Data;
using Infrastructure.Interfaces.IConfiguration;

namespace Application.Handlers.BoardHandlers
{

    public class CreateBoardHandler : IRequestHandler<CreateBoard, Board>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateBoardHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Board> Handle(CreateBoard request, CancellationToken cancellationToken)
        {
            var board = new Board
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