using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Application.Handlers.BoardHandlers
{
    public class GetBoardQueryHandler : IRequestHandler<GetBoardQuery, Board>
    {
        private readonly ApplicationDbContext _context;

        public GetBoardQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Board> Handle(GetBoardQuery request, CancellationToken cancellationToken)
        {
            return await _context.Boards.FirstAsync(board => board.Id == request.Id, cancellationToken: cancellationToken);
        }
    }
}