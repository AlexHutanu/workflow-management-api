using Infrastructure.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IBugTicketRepository BugTickets { get; }
        IActivityRepository Activities { get; }
        IBoardRepository Boards { get; }


        Task CompleteAsync();
    }
}
