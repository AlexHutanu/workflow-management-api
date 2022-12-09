using Infrastructure.Entities;
using MediatR;

namespace Application.Commands
{
    public class CreateActivity : IRequest<Activity>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Owner { get; set; }

        public DateTime TimeCreated { get; set; }
    }
}