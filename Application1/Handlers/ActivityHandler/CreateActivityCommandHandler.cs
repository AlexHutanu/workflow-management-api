using Application.Commands;
using Infrastructure.Entities;
using MediatR;
using WorkflowManagement.Data;

namespace Application.Handlers.ActivityHandler
{


    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Activity>
    {

        private readonly ApplicationDbContext _context;

        public CreateActivityCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Activity> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            _context.Activity.Add(request.NewActivity);
            await _context.SaveChangesAsync(cancellationToken);

            return request.NewActivity;
        }
    }
}