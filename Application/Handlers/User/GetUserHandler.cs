using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Application.Handlers.User;


public class GetUserHandler : IRequestHandler<GetUser, Infrastructure.Entities.UserEntity>
{

    private readonly ApplicationDbContext _context;

    public GetUserHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Infrastructure.Entities.UserEntity> Handle(GetUser request, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstAsync(user => user.Id == request.Id,
            cancellationToken: cancellationToken);
    }
}
