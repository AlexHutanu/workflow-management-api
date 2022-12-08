using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Application.Handlers.ActivityHandlers
{

    public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery, Activity>
    {

        private readonly ApplicationDbContext _context;

        public GetActivityQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Activity> Handle(GetActivityQuery request, CancellationToken cancellationToken)
        {
            return await _context.Activities.FirstAsync(activity => activity.Id == request.Id,
                cancellationToken: cancellationToken);
        }
    }
}