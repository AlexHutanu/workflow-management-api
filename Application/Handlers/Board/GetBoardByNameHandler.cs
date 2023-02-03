using Application.Queries;
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
    public class GetBoardByNameHandler: IRequestHandler<GetBoardByName, IEnumerable<BoardEntity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBoardByNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BoardEntity>> Handle(GetBoardByName request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Boards.GetByName(request.Name);
        }

    }
}
