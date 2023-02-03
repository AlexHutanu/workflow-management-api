using Application.Commands;
using Domain.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Board
{
    public class DeleteBoardHandler : IRequestHandler<DeleteBoard, BoardEntity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteBoardHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BoardEntity> Handle(DeleteBoard request, CancellationToken cancellationToken)
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
