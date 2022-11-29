using Application.Commands;
using Infrastructure.Entities;
using MediatR;
using WorkflowManagement.Data;

namespace Application.Handlers.BoardHandlers
{

    public class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand, Board>
    {

        private readonly ApplicationDbContext _context;

        public CreateBoardCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Board> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            _context.Boards.Add(request.NewBoard);
            await _context.SaveChangesAsync(cancellationToken);

            return request.NewBoard;
        }
    }
}