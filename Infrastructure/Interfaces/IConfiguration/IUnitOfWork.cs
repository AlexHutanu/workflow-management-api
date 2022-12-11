using Infrastructure.Interfaces.IRepositories;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.IConfiguration
{
    public interface IUnitOfWork
    {
        UserRepository Users { get; }
        BugTicketRepository BugTickets { get; }
        ActivityRepository Activities { get; }
        BoardRepository Boards { get; }


        Task CompleteAsync();
    }
}
