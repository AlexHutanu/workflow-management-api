using Application.Commands;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Board
{
    public class UpdateBoardHandler : IRequestHandler<UpdateBoard, Infrastructure.Entities.BoardEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBoardHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Infrastructure.Entities.BoardEntity> Handle(UpdateBoard request, CancellationToken cancellationToken)
        {
            var toUpdate = new Infrastructure.Entities.BoardEntity();

            toUpdate.Description = request.Description;
            toUpdate.Name = request.Name;
            toUpdate.NoOfTickets = request.NoOfTickets;
            toUpdate.Id = request.BoardId;
            toUpdate.UserId = request.UserId;

            await _unitOfWork.Boards.Update(toUpdate);
            await _unitOfWork.CompleteAsync();

            return toUpdate;
        }
    }
}
