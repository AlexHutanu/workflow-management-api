using Application.Commands;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.BoardHandlers
{
    public class DeleteBoardHandler : IRequestHandler<DeleteBoard, Board>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteBoardHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Board> Handle(DeleteBoard request, CancellationToken cancellationToken)
        {
            var board = await _unitOfWork.Boards.GetById(request.BoardId);

            if (board == null)
                return null;

            await _unitOfWork.Boards.Delete(request.BoardId);

            await _unitOfWork.CompleteAsync();

            return board;
        }
    }
}
