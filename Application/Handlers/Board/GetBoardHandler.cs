using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Application.Handlers.Board
{
    public class GetBoardHandler : IRequestHandler<GetBoard, Infrastructure.Entities.BoardEntity>
    {
        private readonly ApplicationDbContext _context;

        public GetBoardHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Infrastructure.Entities.BoardEntity> Handle(GetBoard request, CancellationToken cancellationToken)
        {
            return await _context.Boards.FirstAsync(board => board.Id == request.Id, cancellationToken: cancellationToken);
        }
    }
}