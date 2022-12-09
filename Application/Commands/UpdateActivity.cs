using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using MediatR;

namespace Application.Commands
{
    public class UpdateActivity : IRequest<Activity>
    {
        public Guid ActivityId { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
