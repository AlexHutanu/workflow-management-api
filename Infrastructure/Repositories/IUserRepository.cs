﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity GetByEmail(string email);
    }
}
