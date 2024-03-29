﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteActivity : IRequest<ActivityEntity>
    {
        public Guid ActivityId { get; set; } 
    }
}
