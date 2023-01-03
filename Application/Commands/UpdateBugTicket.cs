using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using MediatR;

namespace Application.Commands
{
    public class UpdateBugTicket : IRequest<BugTicketEntity>
    {
        public Guid BugTicketId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Asignee { get; set; }
        public string? Status { get; set; }
        public double Deadline { get; set; }
        public string? StepsToReproduce { get; set; }
        public string? ExpectedResult { get;set; }
        public string? ActualResult { get; set; }

        public Guid BoardId { get; set; }
    }
}
