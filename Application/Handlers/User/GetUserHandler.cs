using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Application.Handlers.User;


public class GetUserHandler : IRequestHandler<GetUser, UserEntity>
{

    private readonly ApplicationDbContext _context;

    public GetUserHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity> Handle(GetUser request, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstAsync(user => user.Id == request.Id,
            cancellationToken: cancellationToken);
    }
}
