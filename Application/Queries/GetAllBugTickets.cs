using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetAllBugTickets : IRequest<IEnumerable<BugTicketEntity>>
    {
    }
}
