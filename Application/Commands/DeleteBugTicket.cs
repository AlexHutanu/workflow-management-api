﻿using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteBugTicket : IRequest<BugTicketEntity>
    {
        public Guid BugTicketId { get; set; }
    }
}
