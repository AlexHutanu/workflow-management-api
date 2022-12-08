using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Application.Handlers.UserHandlers;


public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
{

    private readonly ApplicationDbContext _context;

    public GetUserQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstAsync(user => user.Id == request.Id,
            cancellationToken: cancellationToken);
    }
}
