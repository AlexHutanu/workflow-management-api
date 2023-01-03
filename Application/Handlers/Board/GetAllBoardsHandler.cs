using Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Application.Handlers.Board
{
    public class GetAllBoardsHandler : IRequestHandler<GetAllBoards, IEnumerable<Infrastructure.Entities.BoardEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBoardsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Infrastructure.Entities.BoardEntity>> Handle(GetAllBoards request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Boards.GetAll();
        }
    }
}
