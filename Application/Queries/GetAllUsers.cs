﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetAllUsers : IRequest<IEnumerable<UserEntity>>
    {
    }
}
