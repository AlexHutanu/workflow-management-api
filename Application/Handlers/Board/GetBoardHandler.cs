using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Application.Handlers.Board
{
    public class GetBoardHandler : IRequestHandler<GetBoard, BoardEntity>
    {
        private readonly ApplicationDbContext _context;

        public GetBoardHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BoardEntity> Handle(GetBoard request, CancellationToken cancellationToken)
        {
            return await _context.Boards.FirstAsync(board => board.Id == request.Id, cancellationToken: cancellationToken);
        }
    }
}