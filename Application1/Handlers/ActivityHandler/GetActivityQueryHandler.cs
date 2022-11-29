using Application.Queries;
using Infrastructure.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkflowManagement.Data;

namespace Application.Handlers.ActivityHandler
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
            return await _context.Activity.FirstAsync(activity => activity.Name == request.Name,
                cancellationToken: cancellationToken);
        }
    }
}