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
    public class UpdateBoardHandler : IRequestHandler<UpdateBoard, Board>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBoardHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Board> Handle(UpdateBoard request, CancellationToken cancellationToken)
        {
            var toUpdate = new Board();

            toUpdate.Description = request.Description;
            toUpdate.Name = request.Name;
            toUpdate.NoOfTickets = request.NoOfTickets;
            toUpdate.Id = request.BoardId;

            await _unitOfWork.Boards.Update(toUpdate);
            await _unitOfWork.CompleteAsync();

            return toUpdate;
        }
    }
}
