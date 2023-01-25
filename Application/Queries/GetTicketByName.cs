﻿using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetTicketByName: IRequest<IEnumerable<TicketEntity>>
    {
        public string Name { get; set; }

        public GetTicketByName(string name)
        {
            Name = name;
        }
    }
}