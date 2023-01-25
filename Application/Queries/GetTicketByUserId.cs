using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetTicketByUserId : IRequest<IEnumerable<TicketEntity>>
    {
        public Guid UserId { get; }

        public GetTicketByUserId(Guid userId)
        {
            UserId = userId;
        }
    }
}
