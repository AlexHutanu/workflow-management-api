using Infrastructure.Repositories;

namespace Infrastructure.Interfaces
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
