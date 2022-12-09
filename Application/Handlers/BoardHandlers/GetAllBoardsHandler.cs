using Application.Queries;
using Infrastructure.Interfaces.IConfiguration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Application.Handlers.BoardHandlers
{
    public class GetAllBoardsHandler : IRequestHandler<GetAllBoards, IEnumerable<Board>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBoardsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Board>> Handle(GetAllBoards request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Boards.GetAll();
        }
    }
}
