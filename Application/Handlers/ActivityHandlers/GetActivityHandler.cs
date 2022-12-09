using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Application.Handlers.ActivityHandlers
{

    public class GetActivityHandler : IRequestHandler<GetActivity, Activity>
    {

        private readonly ApplicationDbContext _context;

        public GetActivityHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Activity> Handle(GetActivity request, CancellationToken cancellationToken)
        {
            return await _context.Activities.FirstAsync(activity => activity.Id == request.Id,
                cancellationToken: cancellationToken);
        }
    }
}