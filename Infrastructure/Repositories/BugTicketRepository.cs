using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.IRepositories;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BugTicketRepository : GenericRepository<BugTicket>, IBugTicketRepository
    {
        public BugTicketRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
