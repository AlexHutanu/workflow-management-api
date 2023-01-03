using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetBugTicketByBoardId : IRequest<IEnumerable<BugTicketEntity>>
    {
        public Guid BoardId { get; }

        public GetBugTicketByBoardId(Guid id)
        {
            BoardId = id;
        }
    }
}
