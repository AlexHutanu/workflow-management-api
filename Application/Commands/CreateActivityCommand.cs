using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class CreateActivityCommand : IRequest<Activity>
    {
        public Activity NewActivity { get; set; }
    }
}