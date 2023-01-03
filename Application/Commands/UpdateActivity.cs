using Infrastructure.Entities;
using MediatR;

namespace Application.Commands
{
    public class UpdateActivity : IRequest<ActivityEntity>
    {
        public Guid ActivityId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
