using Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Handlers.Board
{
    public class GetAllBoardsHandler : IRequestHandler<GetAllBoards, IEnumerable<BoardEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBoardsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BoardEntity>> Handle(GetAllBoards request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Boards.GetAll();
        }
    }
}
