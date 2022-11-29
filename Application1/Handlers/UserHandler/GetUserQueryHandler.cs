using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkflowManagement.Data;

namespace Application.Handlers.UserHandler;


public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
{

    private readonly ApplicationDbContext _context;

    public GetUserQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _context.User.FirstAsync(user => user.Name == request.Name,
            cancellationToken: cancellationToken);
    }
}
