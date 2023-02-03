using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class Activity : IRequest<ActivityEntity>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Owner { get; set; }

        public DateTime TimeCreated { get; set; }
    }
}