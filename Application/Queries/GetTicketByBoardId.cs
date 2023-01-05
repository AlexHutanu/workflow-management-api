using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetTicketByBoardId : IRequest<IEnumerable<TicketEntity>>
    {
        public Guid BoardId { get; }

        public GetTicketByBoardId(Guid id)
        {
            BoardId = id;
        }
    }
}
