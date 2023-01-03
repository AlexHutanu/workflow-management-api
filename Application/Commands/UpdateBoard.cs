using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using MediatR;
using Microsoft.VisualBasic.CompilerServices;

namespace Application.Commands
{
    public class UpdateBoard : IRequest<BoardEntity>
    {
        public Guid BoardId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int NoOfTickets { get; set; }
    }
}
